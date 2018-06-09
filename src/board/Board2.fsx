let length = List.length
let indexed= List.indexed
let filter = List.filter
let map = List.map

let rec find (players: int list) index =
    if length players > 1 then
        let newIndex = (index + 1) % length players
        find
            (indexed players |> filter (fun (i, _) -> i <> newIndex) |> map (fun (_, e) -> e))
            newIndex
    else
        players.[0]

find ([1..100]) 0
|> printfn "%A"

