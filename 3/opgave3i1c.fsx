///<summary>A function that recursively generates a  multiplication table and returns it</summary>
///<param name="n">int : n is the number that decides the scale of the multiplication table</param>
///<returns> A string containing the multiplication table </returns>
let rec recMulTable n =
    let rec row i j =
        if i = 0 then ""
        else (row (i-1) j) + sprintf "%5i" (i*j) 
    if n = 0 then  "     " + row 10 1 + "\n"
    else (recMulTable (n-1)) + (sprintf "%5i" n) + (row 10 n) + "\n"

printfn "%s" (recMulTable 1)
printfn "%s" (recMulTable 2)
printfn "%s" (recMulTable 3)
printfn "%s" (recMulTable 10)

