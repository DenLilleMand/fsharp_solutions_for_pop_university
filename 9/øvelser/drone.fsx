open System

type Drone(startPosition, startSpeed) =
    let mutable currentLocation = startPosition
    let mutable currentSpeed = startSpeed
    member this.position
        with get () = currentLocation
        and set (newLocation) = currentLocation <- newLocation
    member this.speed
        with get () = currentSpeed
        and set ()


let droneOne = new Drone()
