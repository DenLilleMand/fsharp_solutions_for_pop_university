// Relatively generic Test methods
module TestLib

open System

///<summary>
/// A custom Attribute/Annotation used to identify tests
///</summary>
type Test() =
    inherit Attribute()

///<summary>
/// A class with some assertion methods
///</summary>
type Assertions() =
    /// <summary>
    /// Prints a string,
    /// i actually tried to make it a private field
    /// because there is really no reason that the client code
    /// should have access to this method, but it is not
    /// possible to call a private member from a static member,
    /// so i was thinking about letting the static assertion functions
    /// take the printout function as a parameter, that would also allow
    /// some flexibility, but in general there is so much wrong with this
    /// way of doing a testlibrary that il just leave it like this for now.
    /// E.g. we should use annotations/reflection to discover tests, assertions
    /// should only return true/false and then through reflection we should
    /// decouple the way it gets printed, that would also allow us to
    /// add parsers e.g. support JUnit's xml format if we wanted to use
    /// jenkins as CI etc.
    /// </summary>
    /// <params name="string">
    /// stringToBePrinted : string, is the string we're
    /// going to print, can modify this string
    /// by using the sprintf to format it
    /// before you give it as parameter
    /// </params>
    /// <params name="testResult">
    /// Whether the test we're printing out
    /// the result of went good or bad
    /// </params>
    /// <returns>
    /// Unit - only side effects in the sense of printing to console.
    /// </returns>
    static member PrintTestResult (stringToBePrinted : string) testResult =
        if testResult then
          Console.ForegroundColor <- ConsoleColor.Green
        else
          Console.ForegroundColor <- ConsoleColor.Red
        printfn "%s" stringToBePrinted
        Console.ResetColor()

    /// <summary>
    /// AssertEqual asserts if two objects
    /// that both implement the equality operator,
    /// is equal
    /// </summary>
    /// <params name="actual">
    /// Is the value that the program
    /// we're testing has computed
    /// </params>
    /// <params name="expected">
    /// Is the value that we the
    /// program to have computed
    /// </params>
    /// <returns>
    /// Returns the bool true if actual = expected
    /// otherwise false, and has sideeffects in
    /// the sense of printing out the result to console
    /// </returns>
    static member AssertEqual(actual, expected, testName ) =
        if actual = expected then
            let testMessage = (sprintf "Test %s PASSED with 'actual'=%A \
                and 'expected'=%A \u2713" testName actual expected)
            Assertions.PrintTestResult testMessage true
            (true)
        else
            let testMessage = (sprintf "Test %s FAILED with 'actual'=%A and \
                'expected'=%A \u26A0" testName actual expected)
            Assertions.PrintTestResult testMessage false
            (false)

    /// <summary>
    /// Runs a function and handles exceptions if thrown.
    /// Also returns true if expected exception is thrown.
    /// </summary>
    /// <params name="testName">
    ///  testname : string is simply the name of the test,
    ///  which will primarily be used when we print out the test.
    /// </params>
    /// <returns>
    /// returns a boolean, true if equality was false, and false if equality
    /// was true between the two tuples actual and expected.
    /// </returns>
    static member AssertException<'a when 'a :> exn>
        (testName : string) functionToBeTested =
        try
            functionToBeTested()
            Assertions.PrintTestResult (sprintf "Test %s FAILED: \u26A0"
                testName) false
            (false)
        with
        | :? 'a ->
            Assertions.PrintTestResult (sprintf "Test %s PASSED: Raised \
            expected exception \u2713" testName) true
            (true)
        | _ ->
            Assertions.PrintTestResult (sprintf "Test %s FAILED: expected \
                another exception \u26A0" testName) false
            (false)

    /// <summary>
    /// Runs a function and handles exceptions if thrown.
    /// </summary>
    /// <params name="testName">
    ///  testname : string is simply the name of the test,
    ///  which will primarily be used when we print out the test.
    /// </params>
    /// <returns>
    /// returns a boolean, true if equality was false, and false if equality
    /// was true between the two tuples actual and expected.
    /// </returns>
    static member AssertNoException<'a when 'a :> exn>
        (testName : string) functionToBeTested =
        try
            functionToBeTested()
            Assertions.PrintTestResult (sprintf "Test %s PASSED: no exception\
                thrown \u2713" testName) true
            (true)
        with
        | :? 'a ->
            Assertions.PrintTestResult (sprintf "Test %s FAILED: \u26A0"
                testName) false
            (false)
        | _ ->
            Assertions.PrintTestResult (sprintf "Test %s FAILED: expected \
                another exception \u26A0" testName) false
            (false)
    /// <summary>
    /// Tests wether or not the result is equal to the expected result
    /// Expected SHOULD be equal to actual in order to pass
    /// </summary>
    /// <params name="testName">
    ///  testname : string is simply the name of the test,
    ///  which will primarily be used when we print out the test.
    /// </params>
    /// <params name="actual">
    /// Actual : ('a * 'b), is a tuple containing two generic values, and is
    /// the value we're testing
    /// </params>
    /// <params name="expected">
    /// Expected : ('a * 'b), is a tuple containing two generic values
    /// </params>
    /// <returns>
    /// returns a boolean depending on if the test was positive or negative
    /// </returns>
    static member AssertTuplesEqual (testName : string)
        (actual: 'a * 'b) (expected: 'a * 'b) =
        if actual = expected then
            let testMessage =
                sprintf "Test %s PASSED: actual %A expected %A. \u2713"
                    testName actual expected
            Assertions.PrintTestResult testMessage true
            (true)
        else
            let testMessage = (sprintf "Test %s FAILED: actual %A expected %A.\
    \u26A0" testName actual expected)
            Assertions.PrintTestResult testMessage false
            (false)

    /// <summary>
    /// Tests whether or not result is equal to the expected result
    /// expected should NOT be equal to actual to pass this test
    /// </summary>
    /// <params name="testName">
    ///  testname : string is simply the name of the test,
    ///  which will primarily be used when we print out the test.
    /// </params>
    /// <params name="actual">
    /// Actual : ('a * 'b), is a tuple containing two generic values, and is
    /// the value we're testing
    /// </params>
    /// <params name="expected">
    /// Expected : ('a * 'b), is a tuple containing two generic values
    /// </params>
    /// <returns>
    /// returns a boolean, true if equality was false, and false if equality
    /// was true between the two tuples actual and expected.
    /// </returns>
    static member AssertTuplesNotEqual (testName:string)
        (actual:'a * 'b) (expected:'a * 'b) =
        if actual <> expected then
            let testMessage = (sprintf "Test %s PASSED: Found %A not equal to\
     %A. \u2713" testName  actual expected)
            Assertions.PrintTestResult testMessage true
            (true)
        else
            let testMessage = (sprintf "Test %s FAILED: Found %A equal to %A.\
    \u26A0" testName actual expected)
            Assertions.PrintTestResult testMessage false
            (false)
