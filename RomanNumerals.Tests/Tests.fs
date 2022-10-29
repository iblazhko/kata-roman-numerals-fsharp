module Tests

open RomanNumerals
open Xunit
open FsUnit.Xunit

type TestCase =  { Value: int
                   ExpectedRoman: string }

let mapToTestTheoryData testCases =
    testCases
        |> Seq.map (fun x -> [| x |])
        |> Seq.toArray

type ``Roman numerals transformation`` () =

    [<Fact>]
    let ``Edge case: 0 translates to empty string`` () =
        romanize 0 |> should equal ""

    static member NegativeNumbersTestCases
        with get() =
            [|
                { Value =  -1; ExpectedRoman = "-" }
                { Value =  -2; ExpectedRoman = "-" }
                { Value = -42; ExpectedRoman = "-" }
            |]
            |> mapToTestTheoryData

    [<Theory>]
    [<MemberData("NegativeNumbersTestCases")>]
    member verify.``Input validation: negative numbers cannot be converted to roman numeral`` (testCase:TestCase) =
        (fun () -> romanize testCase.Value |> ignore) |> should throw typeof<System.ArgumentOutOfRangeException>

    static member LargeNumbersTestCases
        with get() =
            [|
                { Value = 4000; ExpectedRoman = "-" }
                { Value = 4001; ExpectedRoman = "-" }
                { Value = 10000; ExpectedRoman = "-" }
            |]
            |> mapToTestTheoryData

    [<Theory>]
    [<MemberData("LargeNumbersTestCases")>]
    member verify.``Input validation: numbers larger or equal to 4000 cannot be converted to roman numeral`` (testCase:TestCase) =
        (fun () -> romanize testCase.Value |> ignore) |> should throw typeof<System.ArgumentOutOfRangeException>

    static member SingleLetterNumeralsTestCases
        with get() =
            [|
                { Value =    1; ExpectedRoman = "I" }
                { Value =    5; ExpectedRoman = "V" }
                { Value =   10; ExpectedRoman = "X" }
                { Value =   50; ExpectedRoman = "L" }
                { Value =  100; ExpectedRoman = "C" }
                { Value =  500; ExpectedRoman = "D" }
                { Value = 1000; ExpectedRoman = "M" }
            |]
            |> mapToTestTheoryData

    [<Theory>]
    [<MemberData("SingleLetterNumeralsTestCases")>]
    member verify.``Transformation: single letter roman numerals`` (testCase:TestCase) =
        romanize(testCase.Value) |> should equal testCase.ExpectedRoman

    static member SameLetterNumeralsTestCases
        with get() =
            [|
                { Value =    2; ExpectedRoman = "II"  }
                { Value =    3; ExpectedRoman = "III" }
                { Value =   20; ExpectedRoman = "XX"  }
                { Value =   30; ExpectedRoman = "XXX" }
                { Value =  200; ExpectedRoman = "CC"  }
                { Value =  300; ExpectedRoman = "CCC" }
                { Value = 2000; ExpectedRoman = "MM"  }
                { Value = 3000; ExpectedRoman = "MMM" }
            |]
            |> mapToTestTheoryData

    [<Theory>]
    [<MemberData("SameLetterNumeralsTestCases")>]
    member verify.``Transformation: same letter roman numerals`` (testCase:TestCase) =
        romanize(testCase.Value) |> should equal testCase.ExpectedRoman

    static member SubtractiveNotationTestCases
        with get() =
            [|
                { Value =    4; ExpectedRoman = "IV" }
                { Value =    9; ExpectedRoman = "IX" }
                { Value =   40; ExpectedRoman = "XL" }
                { Value =   90; ExpectedRoman = "XC" }
                { Value =  400; ExpectedRoman = "CD" }
                { Value =  900; ExpectedRoman = "CM" }
            |]
            |> mapToTestTheoryData

    [<Theory>]
    [<MemberData("SubtractiveNotationTestCases")>]
    member verify.``Transformation: subtractive notation roman numerals`` (testCase:TestCase) =
        romanize(testCase.Value) |> should equal testCase.ExpectedRoman

    static member MixedNumbersTestCases
        with get() =
            [|
                { Value =   39; ExpectedRoman = "XXXIX" }
                { Value =  207; ExpectedRoman = "CCVII" }
                { Value =  246; ExpectedRoman = "CCXLVI" }
                { Value = 1066; ExpectedRoman = "MLXVI" }
                { Value = 1776; ExpectedRoman = "MDCCLXXVI" }
                { Value = 1873; ExpectedRoman = "MDCCCLXXIII" }
                { Value = 1984; ExpectedRoman = "MCMLXXXIV" }
                { Value = 2018; ExpectedRoman = "MMXVIII" }
            |]
            |> mapToTestTheoryData

    [<Theory>]
    [<MemberData("MixedNumbersTestCases")>]
    member verify.``Transformation: mixed numbers should translate using additive pattern`` (testCase:TestCase) =
        romanize(testCase.Value) |> should equal testCase.ExpectedRoman


