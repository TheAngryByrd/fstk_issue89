// Learn more about F# at http://docs.microsoft.com/dotnet/fsharp
module V141

open System
open FsToolkit.ErrorHandling

type Id = Id of Guid

type A = { Id : Id }
type B = { Id : Id }

let test () =
    asyncResult {
        let option = async { return Some { A.Id = Guid.NewGuid() |> Id } }
        let! result = option |> AsyncResult.requireSome "none"
        return { B.Id = result.Id }
    }

// Define a function to construct a message to print
let from whom =
    sprintf "from %s" whom

[<EntryPoint>]
let main argv =
    let message = from "F#" // Call the function
    printfn "Hello world %s" message
    0 // return an integer exit code