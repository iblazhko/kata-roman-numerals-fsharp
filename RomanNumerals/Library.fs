namespace RomanNumerals

module Transformer =
    // size -> numerals
    let buckets =
        [   1, "I";
            5, "V";
        ]
        |> List.sortDescending

    let findLargestFullBucker number =
        buckets
        |> Seq.filter (fun (size,_) -> size <= number)
        |> Seq.head

    let rec processBucket numerals reminder =
        match reminder with
        | 0 -> numerals |> String.concat ""
        | n when n > 0 ->
            let bucketSize, bucketNumerals = (findLargestFullBucker n)
            processBucket (List.append numerals [bucketNumerals]) (reminder - bucketSize)

    let romanize number =
        processBucket [] number
