namespace WindowsPhoneApp

open System
open System.Net
open System.Collections.Generic
open System.Windows
open System.Windows.Controls
open System.Windows.Documents
open System.Windows.Ink
open System.Windows.Input
open System.Windows.Media
open System.Windows.Media.Animation
open System.Windows.Shapes
open System.Windows.Navigation
open Microsoft.Phone.Controls
open Microsoft.Phone.Shell
open System.Threading.Tasks
open System.Windows.Threading
open System.Threading
open SignalR.Client

#nowarn "40"
[<AutoOpen>]
module private Utilities = 
    /// This is an implementation of the dynamic lookup operator for binding
    /// Xaml objects by name.
    let (?) (source:obj) (s:string) =
        match source with 
        | :? ResourceDictionary as r ->  r.[s] :?> 'T
        | :? Control as source -> 
            match source.FindName(s) with 
            | null -> invalidOp (sprintf "dynamic lookup of Xaml component %s failed" s)
            | :? 'T as x -> x
            | _ -> invalidOp (sprintf "dynamic lookup of Xaml component %s failed because the component found was of type %A instead of type %A"  s (s.GetType()) typeof<'T>)
        | _ -> invalidOp (sprintf "dynamic lookup of Xaml component %s failed because the source object was of type %A. It must be a control or a resource dictionary" s (source.GetType()))

module SignalR =
    let connection = 
        Connection "http://localhost:8081/chartserver"
    let startConnection() =
        if connection.State = ConnectionState.Disconnected then 
            connection.Start().Start(
                TaskScheduler.FromCurrentSynchronizationContext())

type LanguageChoice = { Language : string; BoxColor : string } 
    
type LanguageChoiceViewModel() =   
    member x.LanguageChoices = 
        let result = List<LanguageChoice>()
        result.Add { Language = "F#"; BoxColor = "#F29925" }
        result.Add { Language = "C#"; BoxColor = "#5492CD" }
        result.Add { Language = "Erlang"; BoxColor = "#E41F26" }
        result.Add { Language = "JavaScript"; BoxColor = "#70BE46" }
        result.Add { Language = "Other"; BoxColor = "#535353" }
        result

type MainPage() as this =
    inherit PhoneApplicationPage()
    do this.DataContext <- LanguageChoiceViewModel()
    do Application.LoadComponent(this, 
        new System.Uri("/WindowsPhoneApp;component/MainPage.xaml", 
            System.UriKind.Relative))

    let confirmationLabel : TextBlock = this?Confirmation

    member this.AnswerButton_Click(sender:obj, e:RoutedEventArgs) =
        let answerButton = sender :?> Button
        SignalR.connection.Send(answerButton.Tag).Start(TaskScheduler.FromCurrentSynchronizationContext())
        confirmationLabel.Text <- "Thanks for Voting!"

/// One instance of this type is created in the application host project.
type App(app:Application) = 
    // Global handler for uncaught exceptions. 
    // Note that exceptions thrown by ApplicationBarItem.Click will not get caught here.
    do app.UnhandledException.Add(fun e -> 
            if (System.Diagnostics.Debugger.IsAttached) then
                // An unhandled exception has occurred, break into the debugger
                System.Diagnostics.Debugger.Break();
     )

    let rootFrame = new PhoneApplicationFrame();

    do app.RootVisual <- rootFrame;

    // Handle navigation failures
    do rootFrame.NavigationFailed.Add(fun _ -> 
        if (System.Diagnostics.Debugger.IsAttached) then
            // A navigation has failed; break into the debugger
            System.Diagnostics.Debugger.Break())

    // Navigate to the main page 
    do rootFrame.Navigate(new Uri("/WindowsPhoneApp;component/MainPage.xaml", UriKind.Relative)) |> ignore

    // Required object that handles lifetime events for the application
    let service = PhoneApplicationService()
    // Code to execute when the application is launching (eg, from Start)
    // This code will not execute when the application is reactivated
    do service.Launching.Add(fun _ -> SignalR.startConnection())
    // Code to execute when the application is closing (eg, user hit Back)
    // This code will not execute when the application is deactivated
    do service.Closing.Add(fun _ -> SignalR.connection.Stop())
    // Code to execute when the application is activated (brought to foreground)
    // This code will not execute when the application is first launched
    do service.Activated.Add(fun _ -> SignalR.startConnection())
    // Code to execute when the application is deactivated (sent to background)
    // This code will not execute when the application is closing
    do service.Deactivated.Add(fun _ -> ())

    do app.ApplicationLifetimeObjects.Add(service) |> ignore
