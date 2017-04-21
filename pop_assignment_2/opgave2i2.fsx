open System

[<EntryPoint>]
let main argv = 
    let helloWorldString = "Hello World"
    printfn "%s" helloWorldString.[.. 5]
    printfn "%s" helloWorldString.[6 .. ]
    0 // return an integer exit code
