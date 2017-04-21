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

let n = sum 10
printf "%i" n 
