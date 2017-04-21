module TestRunner

open System
open System.Reflection
open TestLib

let types = Assembly.GetExecutingAssembly().GetTypes()
let tests =
    types
    |> Array.collect (fun typ -> typ.GetMethods())
    |> Array.choose (fun methodInfo ->
        methodInfo.CustomAttributes
        |> Seq.tryFind (fun attr -> attr.AttributeType = typeof<Test>)
        |> Option.map (fun attr -> attr, methodInfo))

Array.map (fun test ->
    match test with
    | (typeOfTest, methodInfo : MethodInfo) -> 
        methodInfo.Invoke(null, [||]) |> ignore
    ) tests
