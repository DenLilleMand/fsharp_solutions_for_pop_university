///<summary>
///This function removes duplicates from a list while maintaining the order of the 
///elements.
///</summary>
///<params name="xs">
///This list should contain elements that implement the same equality
///</params>
///<returns>
///The function returns a new list with all of the removed duplicates
///</returns>
let removeDuplicates xs = 
    List.toSeq (xs) 
    |> Seq.distinct 
    |> Seq.toList

let removeDuplicates_ (numbers : int list) = 
    let tmp = []
    for i in 0 .. numbers.Length-1 do
        match tmp.[i] with
        | (true, x) -> printfn "true"
        | _ -> printfn "false"



let testNumbers = [5;1;4;4;2;3;1;2;3;4;5;6;7;8;9]
let result = removeDuplicates testNumbers  
printfn "%A" result

