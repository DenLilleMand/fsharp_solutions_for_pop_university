let count (xs : int list, x : int) = 
    let mutable accumulatedCount = 0
    for i in 0 .. xs.Length-1 do
        if xs.[i] = x then
            accumulatedCount <- accumulatedCount + 1
        elif xs.[i] > x
            break
            
    (accumulatedCount)

let xs = [2; 5; 5; 5; 6; 7; 8; 9; 10]




let result1g = count (xs, 5)
printfn "%i" result1g



