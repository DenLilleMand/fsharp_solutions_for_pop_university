///<summary>
///   A sum function using the fact that the numbers from 1-n is triangular, and as such uses a 
///   easy way to calculate these
///</summary>
///<param name="n">int : n is the number we will be accumulating up to</param>
///<returns> The sum of all the numbers from 1 to n </returns>
let simpleSum (n: int) = n*(n+1)/2
let simpleSumN = simpleSum 10
printf "%i" simpleSumN
