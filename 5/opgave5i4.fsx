///<summary>Function that sorts an array using an imperative style</summary>
///<param name="xs"> Is an array of integers</param>
///<returns> Returns a sorted list </returns>
let arraySortD xs = 
    let length = Array.length xs
    let mutable flag = true
    while flag do
        flag <- false
        for i in 1 .. (length-1) do
            if xs.[i-1] > xs.[i] then
                let tmp = xs.[i-1]
                xs.[i-1] <- xs.[i]
                xs.[i] <- tmp
                flag <- true

let aa = [|7;6;5;2;1|]
arraySortD aa
printfn "%A" aa

