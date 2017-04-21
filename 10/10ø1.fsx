type Shift = DayShift=0 | NightShift=2

[<AbstractClass>]
type Employee() =
    abstract member EmployeeName : string
    abstract member EmployeeNumber: int


type ProductionWorker() =
    inherit Employee()
    member val ShiftNumber = Shift.DayShift : Shift with get, set
    member val HourlyPayRate = 106 with get, set
    member val Herpderp = this.ShiftNumber with get, set

    default this.EmployeeName = "Matti Andreas Nielse"
    default this.EmployeeNumber = 1337
    default this.ToString() = (sprintf "Name: %s \
        HourlyPayRate: %d. ShiftNumber: %A. EmployeeNumber: %d"
        this.EmployeeName this.HourlyPayRate this.ShiftNumber
        this.EmployeeNumber)

type ShiftSuperVisor() =
    inherit Employee()
    member val AnnualSalary = 300000 with get, set
    member val AnnualProductionBonus = 0 with get, set
    default this.EmployeeName = "Supervisor name"
    default this.EmployeeNumber = 13377


let matti = new ProductionWorker()
let superVisor = new ShiftSuperVisor()
printfn "%O" matti
