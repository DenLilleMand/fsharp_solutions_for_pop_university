///<summary>A recursive sum function</summary>
///<param name="n">int : n is the number we will be accumulating up to</param>
///<returns> The sum of all the numbers from 1 to n </returns>
let rec recSum n = 
    match n with
    | 0 -> 0
    | _ -> n + recSum (n-1)

let recSumN = recSum 10
printf "%i" recSumN
