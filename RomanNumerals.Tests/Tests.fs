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
let ``1 translates to I`` () =
    romanize 1 |> should equal "I"
