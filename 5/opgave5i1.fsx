///<summary>
///A function that takes a two dimensional list and concats all of the lists
///together into one list
///</summary>
//////<param name="list"> Two dimensional list</param>
///<returns> Returns a single list  </returns>
let concat list = List.collect (fun x -> x) list

let list = [[20;45];[35;37];[50;50]]
printfn "%A" (concat list)
