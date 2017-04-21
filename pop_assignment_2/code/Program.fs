// Learn more about F# at http://fsharp.org

open System

[<EntryPoint>]
let main argv = 
    let randomString = "Hello World"
    printfn "%s" randomString.[.. 5]
    printfn "%s" randomString.[6 .. ]
    0 // return an integer exit code
