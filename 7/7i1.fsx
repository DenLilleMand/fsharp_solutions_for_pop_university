open System
open System.IO

///<summary>
/// fileReplace is a function that takes a filename, a word
/// and another word, it then replaces the first word with
/// the second word.
///</summary>
///<param name="filename">
/// Name of the file we want to do the replacement in
///</param>
///<param name="needle">
/// The word we're going to replace
///</param>
///<param name="replace">
/// The name we will replace the needle with.
///</param>
///<returns>Unit</returns>
let fileReplace (filename: string) (needle: string) (replace: string) =
    let lines = File.ReadAllLines filename
    let linesWithReplacements =
        Array.map (fun (x : string) -> x.Replace(needle, replace)) lines
    File.WriteAllLines(filename, linesWithReplacements)

fileReplace "7i1_testfile.txt" "needle" "replacement-needle"
