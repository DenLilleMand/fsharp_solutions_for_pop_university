open System

///<summary>
///</summary>
///<param>
///</param>
///<return>
///</return>
type Moth(x : float, y : float) =
    let mutable position = (x, y)
    member this.moveToLight (x: float, y: float) =
        position <- (fst position + (x/2.0), snd position + (y/2.0))
    member this.getPosition = fun () -> position

let johnny = new Moth(0.0, 0.0)
johnny.moveToLight(100.0, 100.0)
let position = johnny.getPosition()
printfn "position: X:%A Y:%A" (fst position) (snd position)

let lars = new Moth(-50.0, -40.0)
lars.moveToLight(100.0, 100.0)
let larsPosition = lars.getPosition()
printfn "position: X:%A Y:%A" (fst larsPosition) (snd larsPosition)
