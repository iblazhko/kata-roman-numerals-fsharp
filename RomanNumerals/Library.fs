namespace RomanNumerals

module Transformer =
    let romanize number =
        match number with
        | 0 -> ""
        | 1 -> "I"
        | 5 -> "V"
