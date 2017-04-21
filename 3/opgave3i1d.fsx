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

///<summary>A function that returns the multiplication table</summary>
///<param name="n">int : n is the number that decides the scale of the multiplication table</param>
///<returns> A string containing the multiplication table </returns>
let mulTable n =
   let table =
       "     1   2   3   4   5   6   7   8   9  10\n" +
       " 1   1   2   3   4   5   6   7   8   9  10\n" +
       " 2   2   4   6   8  10  12  14  16  18  20\n" +
       " 3   3   6   9  12  15  18  21  24  27  30\n" +
       " 4   4   8  12  16  20  24  28  32  36  40\n" +
       " 5   5  10  15  20  25  30  35  40  45  50\n" +
       " 6   6  12  18  24  30  36  42  48  54  60\n" +
       " 7   7  14  21  28  35  42  49  56  63  70\n" +
       " 8   8  16  24  32  40  48  56  64  72  80\n" +
       " 9   9  18  27  36  45  54  63  72  81  90\n" +
       "10  10  20  30  40  50  60  70  80  90 100\n"
   (table.[..(((n + 1)*43)-1)])


///<summary>A function that recursively generates a  multiplication table and returns it</summary>
///<param name="n">int : n is the number that decides the scale of the multiplication table</param>
///<returns> A string containing the multiplication table </returns>
let rec recMulTable n =
    let rec row i j =
        if i = 0 then ""
        else (row (i-1) j) + sprintf "%5i" (i*j) 
    if n = 0 then  "     " + row 10 1 + "\n"
    else (recMulTable (n-1)) + (sprintf "%5i" n) + (row 10 n) + "\n"


 
let columns = [|"n"; "MulTable n = loopMulTable n "; "MulTable n = recMulTable n"|]
printfn "\n Starting assignment opgave3i1d output:"
printfn "\n----------------------------------------------------------------------------------------------"
for i in 0 .. columns.Length-1 do
    if i = columns.Length-1 then
        printf "|%30s|" columns.[i]
    else
        printf "|%30s" columns.[i]

printfn "\n----------------------------------------------------------------------------------------------"

for i' in 0 .. 10 do
    for j in 0 .. columns.Length do
        if j = columns.Length-1 then
            let mulTableResult = mulTable i'
            let loopMulTableResult =  loopMulTable i'
            let recMulTableResult = recMulTable i'
            printf "|%30i|%30s|%30s|\n" i' (string(mulTableResult = loopMulTableResult)) (string(mulTableResult = recMulTableResult))
