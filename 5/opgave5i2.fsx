///<summary>
/// A function that takes a list of floats, if the list is empty it returns
/// a Option.None and otherwise it returns a Option.Some containing the
/// average of all the floats
///</summary>
///<param name="list"> List of floats</param>
///<returns>
/// A Option, either Option.None if the list is empty or Option.Some otherwise
///</returns>
let gennemsnit (list : float list) =
    match list with
    | [] -> None
    | _ ->
        Some(List.fold (fun accumulated entry ->
            accumulated + float entry) 0.0 list / float list.Length
        )

let floats = [20.2; 20.5; 20.7; 20.37]
printf "%A" (Option.toList (gennemsnit floats))
