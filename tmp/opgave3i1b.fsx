///<summary>A function that uses 2 loops that accumulates a multiplication table and returns it</summary>
///<param name="n">int : n is the number that decides the scale of the multiplication table</param>
///<returns> A string containing the multiplication table </returns>
let loopMulTable n =
    let mutable s = "         1    2    3    4    5    6    7    8    9   10\n"
    for i = 1 to n do
        s <- s + (sprintf "%5i" i)
        for j = 1 to 10 do
            s <- s + sprintf "%5i" (j * i)
        s <- s + "\n"
    (s)

printfn "Starting output for assignment 3i1b . . . \n"
printfn "loop multable n = 1:\n"
printfn "%s" (loopMulTable 1)
printfn "loop multable n = 2:\n"
printfn "%s" (loopMulTable 2)
printfn "loop multable n = 3:\n"
printfn "%s" (loopMulTable 3)
printfn "loop multable n = 10:\n"
printfn "%s" (loopMulTable 10)


    
