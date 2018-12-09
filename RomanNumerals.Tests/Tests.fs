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

[<Fact>]
let ``5 translates to V`` () =
    romanize 5 |> should equal "V"

[<Fact>]
let ``2 translates to II`` () =
    romanize 2 |> should equal "II"
