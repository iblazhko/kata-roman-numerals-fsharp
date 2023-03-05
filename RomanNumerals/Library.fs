module RomanNumerals

// size -> numerals
let private buckets =
    [   1, "I"
        5, "V"
        10, "X"
        50, "L"
        100, "C"
        500, "D"
        1000, "M"

        4, "IV"
        9, "IX"
        40, "XL"
        90, "XC"
        400, "CD"
        900, "CM"
    ]
    |> Seq.sortDescending

let private findLargestFullBucket number =
    buckets
    |> Seq.filter (fun (size,_) -> size <= number)
    |> Seq.head

let rec private processBucket numerals reminder =
    match reminder with
    | 0 -> numerals |> String.concat ""
    | n ->
        let bucketSize, bucketNumerals = (findLargestFullBucket n)
        processBucket (List.append numerals [bucketNumerals]) (reminder - bucketSize)

let romanize number =
    if (number < 0 || number >= 4000) then raise (System.ArgumentOutOfRangeException("number", "Expected a number in the range [0,4000)"))

    processBucket [] number
