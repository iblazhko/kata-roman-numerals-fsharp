namespace RomanNumerals

module Transformer =
    let romanize number =
        match number with
        | 0 -> ""
        | 1 -> "I"
        | 2 -> "II"
        | 5 -> "V"
