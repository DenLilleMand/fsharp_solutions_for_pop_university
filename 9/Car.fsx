module Car

open System

///<summary>
/// A class representing a car
///</summary>
///<param name="_yearOfModel">
/// A integer representing
/// the year the model was invented
/// with format "YYYY"
///</param>
///<param name="_make">
/// The model of the car
///</param>
type Car(_yearOfModel: int, _make : string) =
    let mutable yearOfModel = _yearOfModel
    let mutable make = _make
    let mutable speed = 0
    let mutable benzin = 0
    member this.YearOfModel
        with set(value) = yearOfModel <- value
        and get() = yearOfModel
    member this.Make
        with set(value) = make <- value
        and get() = make
    member this.Speed
        with set(value) = speed <- value
        and get() = speed
    member this.Benzin
        with set(value) =
            if value < 0 then
                raise( new Exception())
            else
                benzin <- value
        and get() = benzin

    ///<summary>
    /// Accelerate is a function that
    /// decrements the gas/benzin with 5 and at the same
    /// time increments the speed with 5
    ///</summary>
    member this.Accelerate() =
        if (this.Benzin - 5) < 0 then
            this.Speed <- 0
            this.Benzin <- 0
            raise(new Exception())
        else
            this.Benzin <- this.Benzin - 5
            this.Speed <- this.Speed + 5

    ///<summary>
    /// Brake is a function that
    /// decrements benzin/gas and speed
    /// by 5, even though it makes no
    /// sense
    ///</summary>
    member this.Brake() =
        this.Benzin <- this.Benzin - 5
        this.Speed <- this.Speed - 5
