///<summary>A sum function that uses a local variable to store the tmp. value until it is returned </summary>
///<param name="n">int : n is the number we will be accumulating up to</param>
///<returns> The sum of all the numbers from 1 to n </returns>
let sum (n : int) =  
    let mutable accumulated_sum = 0
    let mutable i = 0
    while i < n+1 do
        accumulated_sum <- accumulated_sum + i
        i <- i + 1
    (accumulated_sum)

///<summary>A recursive sum function</summary>
///<param name="n">int : n is the number we will be accumulating up to</param>
///<returns> The sum of all the numbers from 1 to n </returns>
let rec recSum n = 
    match n with
    | 0 -> 0
    | _ -> n + recSum (n-1)

///<summary>
///   A sum function using the fact that the numbers from 1-n is triangular, and as such uses a 
///   easy way to calculate these
///</summary>
///<param name="n">int : n is the number we will be accumulating up to</param>
///<returns> The sum of all the numbers from 1 to n </returns>
let simpleSum (n: int) = n*(n+1)/2

let columns = [|"n"; "sum n"; "recSum n"; "simpleSum n"|]
printfn "\n Starting assignment d output:"
printfn "\n-----------------------------------------------------"
for i in 0 .. columns.Length-1 do
    if i = columns.Length-1 then
        printf "|%12s|" columns.[i]
    else
        printf "|%12s" columns.[i]
printfn "\n-----------------------------------------------------"
for i' in 0 .. 10 do
    for j in 0 .. columns.Length do
        if j = columns.Length-1 then
            let sumN = sum i'
            let recSumN = recSum i'
            let simpleSumN =  simpleSum i'
            printf "|%12i|%12i|%12i|%12i|\n" i' sumN recSumN simpleSumN
