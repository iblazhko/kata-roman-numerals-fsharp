namespace RomanNumerals

module Transformer =
    // size -> numerals
    let buckets =
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
        |> List.sortDescending

    let findLargestFullBucker number =
        buckets
        |> Seq.filter (fun (size,_) -> size <= number)
        |> Seq.head

    let rec processBucket numerals reminder =
        match reminder with
        | 0 -> numerals |> String.concat ""
        | n ->
            let bucketSize, bucketNumerals = (findLargestFullBucker n)
            processBucket (List.append numerals [bucketNumerals]) (reminder - bucketSize)

    let romanize number =
        processBucket [] number
