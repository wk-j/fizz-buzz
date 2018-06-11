
let filteri (predicate: (int * 'a) -> bool) data  =
    let mutable index = 0
    [for item in data do
        if predicate(index, item) then yield item
        index <- index + 1]

let rec play players skip startIndex =
    match players with
    | [finalPlayer] -> finalPlayer
    | remain ->
        let skipIndex = (startIndex + skip) % List.length players
        let nextPlayer = filteri (fun (i, _) -> i <> skipIndex) remain
        play nextPlayer skip skipIndex

play [1..100] 1 0
|> printfn "%A"

