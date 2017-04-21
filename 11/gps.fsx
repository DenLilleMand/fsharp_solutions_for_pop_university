open System

let random = System.Random()
let exp number x =
    let mutable result = 0.0 
    for x in 0 .. x do
        result <- number * number
    (result)

type Waypoint(longitude : float, latitude : float, name : string) =
    member val Longitude = longitude : float with get, set
    member val Latitude = latitude : float with get, set
    member val Name = name : string with get, set

type GPS() =
    member val Waypoints : Waypoint List = [] with get, set
    member this.AddWaypoint (waypointName : string) = 
        let waypoint = new Waypoint((float (random.Next(-180, 180))), float(random.Next(-90, 90)), waypointName) 
        this.Waypoints <- List.append this.Waypoints [waypoint]
        
    //minus x1,y1, og x2, y2 med hinanden, og brug så sqrt(a_{1}^2+a_{2}^2) til at finde afstanden.
    member this.CalculateDistance (originWaypoint : Waypoint) (destWaypoint : Waypoint) =
        let a1 = (originWaypoint.Longitude) - (destWaypoint.Longitude)
        let a2 = (originWaypoint.Latitude) - (destWaypoint.Latitude)
        let a1exp = exp a1 2
        let a2exp = exp a2 2
        let product = a1exp + a2exp
        Math.Sqrt(product)


let gps = new GPS()
gps.AddWaypoint "school"
gps.AddWaypoint "whatever"


printfn "Distance: %f" (gps.CalculateDistance gps.Waypoints.[0] gps.Waypoints.[1])
