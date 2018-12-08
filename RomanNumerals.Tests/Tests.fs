module Tests

open RomanNumerals.Transformer
open System
open Xunit
open FsUnit
open FsUnit.Xunit

[<Fact>]
let ``0 translates to empty string`` () =
    romanize 0 |> should equal ""
