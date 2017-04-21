open System

type Car() =
    let mutable benzin = 0
    member this.AddGas(value) = benzin <- value + benzin
    member this.GasLeft = benzin
    member this.Drive(kilometers) =
        if (benzin - kilometers) < 0 then
            raise (Exception("Out of gas"))
        else
            benzin <- benzin - kilometers


type CarTest() =
    static member TestAddGasEqual testName actual expected =
        if actual = expected then
            printfn "TestAddGasEqual tested: %s which SUCCEEDED with argument actual: %A and expected: %A " testName actual expected
            (true)
        else
            printfn "TestAddGasEqual tested: %s which FAILED with argument actual: %A and expected: %A " testName actual expected
            (false)
    static member TestAddGasUnequal testName actual expected =
        if actual <> expected then
            printfn "TestAddGasUnequal tested: %s which SUCCEEDED with argument actual: %A and expected: %A " testName actual expected
            (true)
        else
            printfn "TestAddGasUnequal tested: %s which FAILED with argument actual: %A and expected: %A " testName actual expected
            (false)
    static member AssertException<'a when 'a :> exn> testName functionToBeTested =
        try
            functionToBeTested()
            printfn "AssertException tested: %s which FAILED" testName
            (false)
        with
        | :? 'a ->
            printfn "TestAddGasUnequal tested: %s which SUCCEEDED" testName
            (true)
        | _ ->
            printfn "AssertException tested: %s which FAILED" testName
            (false)

let car1 = new Car()

car1.Drive 30
CarTest.TestAddGasEqual "Testing that drive actually reduces gas with the appropiate amount " car1.GasLeft 20 |> ignore
CarTest.TestAddGasUnequal "Testing that drive actually reduces gas with the appropiate amount " car1.GasLeft 10 |> ignore
CarTest.AssertException<Exception> "Testing if Drive actually throws an exception if it goes below 0 in benzin" (fun () -> car1.Drive 60) |> ignore
