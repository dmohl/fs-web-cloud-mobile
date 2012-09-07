#r "System"
#r "EnvDTE.dll"
#r "EnvDTE80.dll"
#r "Microsoft.VisualStudio.OLE.Interop"
#r "System.Xml.Linq"
#r "NuGet.Core.dll"

module internal nuget = 
    open System.IO
    open EnvDTE
    open EnvDTE80
    open System.Runtime.InteropServices
    open NuGet

    let packageSourceUrl = "https://go.microsoft.com/fwlink/?LinkID=206669"
    let packageSource = PackageSource(packageSourceUrl).Source
    let repositoryFactory = PackageRepositoryFactory() 
    let repository = repositoryFactory.CreateRepository packageSource

    let GetDte2() =
        Marshal.GetActiveObject("VisualStudio.DTE.11.0") :?> DTE2

    let GetDocumentPath () = 
        try      
            match GetDte2() with
            | dte2 when dte2.Solution = null -> dte2.ActiveDocument.Path
            | dte2 -> Path.GetDirectoryName dte2.Solution.FullName
        with
        | _ -> failwith "A solution must be loaded."

    let SendToFsiConsole text = printfn "%s\r\n" text

    let GetRepositoryPath path = Path.Combine(path, "packages")

    let InstallPackages (repositoryId:string) (destinationPath:string) =
        "Creating the package manager." |> SendToFsiConsole
        let packageManager = 
            PackageManager(repository, DefaultPackagePathResolver destinationPath, 
                           PhysicalFileSystem(GetRepositoryPath destinationPath))
        "Retrieving the package from the NuGet Repository. " + 
        "This may take several minutes..." |> SendToFsiConsole
        
        packageManager.InstallPackage repositoryId
    
    let AddReferenceToFsx referenceName =
        let dte2 = GetDte2()
        if dte2.ActiveDocument.Name.Contains ".fsx" then
            let doc = dte2.ActiveDocument.Object "TextDocument" :?> TextDocument
            let editPoint = doc.CreateEditPoint()
            if not ((editPoint.GetText doc.EndPoint).Contains(referenceName)) then
                editPoint.Insert(sprintf "#r @\"%s\"\r\n" referenceName)

    let (|IsFrameworkSpecific|_|) (input:string) =
        let libIndex = input.IndexOf("\\lib\\") + 5
        let modifiedInput = input.Substring(libIndex, input.Length - libIndex)
        match modifiedInput.Contains("\\") with
        | true -> Some ()
        | _ -> None

    let UpdateReference path =    
        Directory.GetFiles(GetRepositoryPath path, "*.dll", 
                           SearchOption.AllDirectories) 
        |> Seq.filter(fun file -> file.ToLower().Contains("lib") 
                                  && (not (file.ToLower().Contains("tools")))
                                  && (not (file.ToLower().Contains("content"))) )
        |> Seq.iter(fun file -> 
                        match file with
                        | IsFrameworkSpecific -> 
                            if file.ToLower().Contains("net40") then
                                AddReferenceToFsx file
                        | _ -> AddReferenceToFsx file )

    let InstallPackage packageName =
        let documentPath = GetDocumentPath() 
        InstallPackages packageName documentPath
        sprintf "%s has been retrieved successfully. Now updating the references." packageName |> SendToFsiConsole
        UpdateReference documentPath
        sprintf "%s has been added successfully." packageName |> SendToFsiConsole 
 
    let ShowInstalledPackages () =
        try
            let documentPath = GetDocumentPath()            
            Directory.GetDirectories(GetRepositoryPath documentPath)
            |> Seq.iter (fun dir -> let array = dir.Split([|'\\'|]) |> Array.rev 
                                    array.[0] |> SendToFsiConsole )
        with
        | _ -> "There are no packages currently installed" |> SendToFsiConsole 

let InstallPackage packageName = nuget.InstallPackage packageName
 
let ShowInstalledPackages () = nuget.ShowInstalledPackages()
