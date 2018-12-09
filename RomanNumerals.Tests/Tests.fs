module Tests

open RomanNumerals.Transformer
open System
open Xunit
open FsUnit
open FsUnit.Xunit

[<Fact>]
let ``0 translates to empty string`` () =
    romanize 0 |> should equal ""

[<Fact>]
let ``4 translates to IV`` () =
    romanize 4 |> should equal "IV"

type TestCase =
    {
        Value: int
        ExpectedRoman: string
    }

type ``Roman numerals transformation`` () =
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
            |> Seq.map (fun (x) -> [| x |])
            |> Seq.toArray

    [<Theory>]
    [<MemberData("SingleLetterNumeralsTestCases")>]
    member verify.``Single letter roman numerals`` (testCase:TestCase) =
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
            |> Seq.map (fun (x) -> [| x |])
            |> Seq.toArray

    [<Theory>]
    [<MemberData("SameLetterNumeralsTestCases")>]
    member verify.``Same letter roman numerals`` (testCase:TestCase) =
        romanize(testCase.Value) |> should equal testCase.ExpectedRoman
