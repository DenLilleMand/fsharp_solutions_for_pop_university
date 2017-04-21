type Laser(power : int, name : string ) = class
    let mutable power = 50
    static member StaticProperty = "this is a static property"
    member x.Power =
        with get() = power
        and set(value) =
            if value < 1 then raise (new Exception("Laser out of power"))
            else power <- value
    member x.name = name
    member x.findTarget() = power <- power - 1
    member x.shoot() = power <- power - 10
    end

let laser1 = new Laser(47, "herpderp")
