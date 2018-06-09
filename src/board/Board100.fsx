let players = [1..10]


let rec last (players: int list ): int  =
    printfn "%A" players
    if players.Length = 1 then
        players.[0]
    else
        let newPlayers =
            players
            |> List.mapi (fun i e -> (i, e))
            |> List.filter (fun (i, _) -> i % 2 <> 1)
            |> List.map (fun (_, e) -> e)
        last newPlayers


last players |> printfn "%A"