open System
open System.Text.RegularExpressions
open System.Net
open System.IO

///<summary>
/// countLinks is a function that takes a url, fetches the html page
/// from that url, reads all of the content into a string, 
/// then it declares a regular expression matching the opening
/// of a tags, continues to match until the match isn't a success
/// anymore, then it returns the count
///</summary>
///<param name="url">The url for the webpage we're interested in</param>
///<returns>The count of all of the opening a tags</returns>
let countLinks url =
    let request = WebRequest.Create(Uri url)
    use response = request.GetResponse()
    use stream = response.GetResponseStream()
    use reader= new IO.StreamReader(stream)
    let html = reader.ReadToEnd()
    let mutable regexResult = Regex.Match(html, "<a.*?href.*?>")
    let mutable count = 0
    while regexResult.Success do 
        count <- count + 1
        regexResult <- regexResult.NextMatch()
    (count)

printfn "Count: %d" (countLinks "http://www.tv2.dk")

