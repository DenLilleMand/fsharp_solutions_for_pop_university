open System

///<summary>
///  safeIndexIf takes an array and index, checks if the index is
///  within the bounds,if it is we return the value on the given index,
///  otherwise we return a generic default value which is
///  ultimately decided by the type of the input array.
///</summary>
///<param name="arr">A generic array</param>
///<param name="i">The index</param>
///<returns>
///    The value on the given index or default value if the index is out of
///    bound
///</returns>
let safeIndexIf arr i =
    if ((Array.length arr)-1 > i) then
        arr.[i]
    else
        Unchecked.defaultof<'a>

///<summary>
/// safeIndexTry takes an array and a index, checks if the index is within
/// the bounds of the array, if it is we return the value on that index,
/// otherwise we catch the exception with a try-with and raises it,
/// basically passing it on to the caller.
///</summary>
///<param name="arr">A generic array</param>
///<param name="i">The index</param>
///<returns>
///    The value on the given index
///</returns>
let safeIndexTry (arr: 'a[]) i =
    try
        arr.[i]
    with
        | :? IndexOutOfRangeException ->
            raise(IndexOutOfRangeException("Index out of range"))

///<summary>
/// safeIndexOption takes an array and a index as arguments, checks if the
/// index  is within the bounds of the array. If it is we return a Option.Some
/// containing the value on that index, otherwise we return a Option.None
///</summary>
///<param name="arr">A generic array</param>
///<param name="i">The index</param>
///<returns>
///    If the index is within bounds of the array Option.Some(the value),
///    otherwise we return Option.None
///</returns>
let safeIndexOption arr i =
    if ((Array.length arr)-1 > i) then
        Some(arr.[i])
    else
        None

let emptyArray = [||]
let fullArray = [|5; 4; 3; 2; 1|]


printfn "SafeIndexIf with correct input: %i " (safeIndexIf fullArray 2)
printfn "SafeIndexIf with incorrect input: %i"  (safeIndexIf fullArray 9)

printfn "SafeIndexTry with correct input: %i" (safeIndexTry fullArray 2)
try
    printfn "SafeIndexTry with incorrect input: %i" (safeIndexTry fullArray 9)
with
    | :? IndexOutOfRangeException ->
        printfn "SafeIndexTry with incorrect input:
            We got an exception as expected"

printfn "SafeIndexOption with correct input: %A" (Option.get (safeIndexOption fullArray 2))
printfn "SafeIndexOption with incorrect input: %O" (safeIndexOption fullArray 9)
