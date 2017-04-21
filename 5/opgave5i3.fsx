///<summary>
///  A function that takes an array and sorts it
///</summary>
///<param name="xs"> An array of items that implements comparison</param>
///<returns> The sorted array </returns>
let rec arraySort xs =
    match xs with
    | [| |] -> xs
    | [|x|] -> xs
    | xs ->
        let head = xs.[0]
        let tail = xs.[1..]
        Array.collect (fun x -> x) [| arraySort (Array.filter((>=) head) tail); xs.[..0] ; arraySort (Array.filter((<) head) tail) |]

let _ : ('a[] -> 'a[]) when 'a : comparison = arraySort

let unsortedArray = [|1;7;5;2;1;7;1;7;1;7;1|]
let sortedArray = arraySort unsortedArray
printfn "%A \n" unsortedArray
printfn "%A \n" sortedArray

        
