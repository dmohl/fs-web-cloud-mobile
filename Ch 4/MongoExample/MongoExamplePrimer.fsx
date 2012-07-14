#r "./packages/mongocsharpdriver.1.5/lib/net35/MongoDB.Bson.dll"
#r "./packages/mongocsharpdriver.1.5/lib/net35/MongoDB.Driver.dll"
#r "./packages/MongoFs.0.1.0.0/lib/MongoFs.dll"

open MongoDB.Bson
open MongoDB.Driver
open MongoDB.Driver.Builders

[<CLIMutable>]
type Contact = {
    _id : ObjectId
    FirstName : string
    LastName : string
    Phone : string
}

let contacts = 
    createLocalMongoServer()
    |> getMongoDatabase "contactDb"
    |> getMongoCollection "contacts"

{ _id = ObjectId.GenerateNewId(); FirstName = "test"; LastName = "It"; Phone = "123-123-1233" }
|> contacts.Insert

let contact = contacts.FindOne()
printfn "The content is %s, %s, %s" contact.FirstName contact.LastName contact.Phone 
