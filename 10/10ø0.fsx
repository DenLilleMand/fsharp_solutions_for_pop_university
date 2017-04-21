[<AbstractClass>]
type Person() =
    abstract member Name : string 
    abstract member Address : string 
    abstract member TelephoneNumber : int 

type Customer() =
    inherit Person()
    member val CustomerNumber = 0 with get, set
    member val IsSubscribed = false with get, set
    default this.Name = "Matti Nielsen" 
    default this.Address = "Peter Bangs Vej 46 1th"
    default this.TelephoneNumber = 30133834
    default this.ToString() = (sprintf "Name: %s. CustomerNumber: %d \
        Address: %s. TelephoneNumber: %d. \
        IsSubscribed: %b. " this.Name this.CustomerNumber this.Address this.TelephoneNumber this.IsSubscribed)

let matti = new Customer()
printfn "%O" matti
