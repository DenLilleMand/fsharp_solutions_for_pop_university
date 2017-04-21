module Tests

open System
open Car
open TestLib

///<summary>
/// Testing if the constructor and default values work
/// as expected
///</summary>
type CarConstructorTests = class
    [<Test>]
    static member TestConstructor_IsYearOfModelCorrectDefault_ExpectYes() =
        //arrange
        let car = new Car(2016, "V750")
        //setup
        //assertion
        Assertions.AssertEqual(2016, car.YearOfModel, "Car constructor, \
            is year of model the correct default, expecting yes. " )

    [<Test>]
    static member TestConstructor_IsMakeCorrectDefault_ExpectYes() =
        //arrange
        let car = new Car(2016, "V750")
        //setup
        //assertion
        Assertions.AssertEqual("V750", car.Make, "Car constructor \
            is make the correct default, expecting yes")

    [<Test>]
    static member TestConstructor_IsSpeedCorrectDefault_ExpectYes() =
        //arrange
        let car = new Car(2016, "V750")
        //setup
        //assertion
        Assertions.AssertEqual(0, car.Speed, "Car constructor \
            is make the correct default, expecting yes")

    [<Test>]
    static member TestConstructor_IsBenzinCorrectDefault_ExpectYes() =
        //arrange
        let car = new Car(2016, "V750")
        //setup
        //assertion
        Assertions.AssertEqual(0, car.Benzin, "Car constructor \
            has the correct default speed, expecting yes")
end

///<summary>
/// Testing if the Accelerate method works
/// as its suppose to in the car class
///</summary>
type CarAccelerationTests =
    [<Test>]
    static member TestAcceleration_RunOutOfBenzin_ExpectException() =
        //arrange
        let car = new Car(2016, "V750")
        //setup
        car.Benzin <- 0

        //assertion
        Assertions.AssertException<Exception> "Car Accelerate, run out of \
            benzine, expect exception" (fun () -> car.Accelerate())

    [<Test>]
    static member TestAcceleration_RunAccelerateOnce_ExpectFiveLess() =
        //arrange
        let car = new Car(2016, "V750")

        //setup
        car.Benzin <- 50
        car.Accelerate()
        Assertions.AssertEqual(45, car.Benzin, "Car Accelerate, run \
            acceerlate once with 50 benzine, expect (five less)45")

    [<Test>]
    static member TestAcceleration_DontRunOutOfBenzine_ExpectNoException() =
        //arrange
        let car = new Car(2016, "V750")

        //setup
        car.Benzin <- 50
        car.Accelerate()
        car.Accelerate()
        car.Accelerate()
        car.Accelerate()
        car.Accelerate()
        car.Accelerate()
        car.Accelerate()
        car.Accelerate()
        car.Accelerate()
        Assertions.AssertNoException<Exception> "Car accelerate, not running \
            out of benzine, so expecting no exception to be thrown when\
            accelerating continiously" (fun () -> car.Accelerate())

///<summary>
/// Testing if the Brake method works
/// as its suppose to in the car class
///</summary>
type CarBrakeTests =
    [<Test>]
    static member TestBrake_BringsBenzineToZero_ExpectsYesAparently() =
        //arrange
        let car = new Car(2016, "V750")
        //setup
        car.Benzin <- 10
        car.Brake()
        car.Brake()
        Assertions.AssertEqual(0, car.Benzin, "Car brake,  eventually brings\
            benzine to zero when braking")

    [<Test>]
    static member TestBrake_BringSpeedToZero_ExpectsYes() =
        //arrange
        let car = new Car(2016, "V750")
        //setup
        car.Benzin <- 20
        car.Accelerate()
        car.Accelerate()
        car.Brake()
        car.Brake()
        Assertions.AssertEqual(0, car.Speed, "Car brake,  brings speed\
            to zero when braking")
