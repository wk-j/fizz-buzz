let filteri (con: (int * 't) -> bool) (data: 't list) : 't list =
    let mutable index = 0
    [for item in data do
        if con(index, item) then yield item
        index <- index + 1
    ]

let rec play players skip startIndex =
    match players with
    | [final] -> final
    | remain ->
        let skipIndex = (startIndex + skip) % List.length players
        play (filteri (fun (i, _) -> i <> skipIndex) remain) skip skipIndex

play [1..100] 1 0
|> printfn "%A"