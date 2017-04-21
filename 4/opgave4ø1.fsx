///4.1: Declare function upto: int -> int list such that upto n=[1;2;...;n]
let upto n = [1 .. n]
///printfn "%A" (upto 50)


///4.7: Declare an F# function multiplicityx xs to find the number of times the value x occurs in the list xs (there is some weird casting, between x :: xs  to list, even if xs is array, and [| |] is for arrays and [] seems to be for lists. Seems easier to use lists in F#
let multiplicity (n : int) (xs : int array) = 
    match xs with 
    | [| |] -> 0
    | _ -> Array.length (Array.filter (fun x -> x = n ) xs)
        
let numbersWithDuplicates : int array = [| 5; 5; 5; 1; 3; 4; 5; 6; 7|]

printfn "%i" (multiplicity 5 numbersWithDuplicates)

//4.8: Declare an F# function split such that

        
    



