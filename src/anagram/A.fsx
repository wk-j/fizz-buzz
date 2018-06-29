
let anagram i1 i2 =
    let length (x, values) = x, values |> Seq.length
    let g1 = i1 |> Seq.groupBy (id) |> Seq.map (length)
    let g2 = i2 |> Seq.groupBy (id) |> Seq.map (length)
    g2 |> Seq.forall(fun (x,xv) ->
        Seq.exists (fun (k, kv) -> k = x && xv <= kv) g1
    )

anagram "abcde" "bad"
|> printfn "%A"

anagram "abcde" "bat"
|> printfn "%A"

anagram "abcdefg" "cabbage"
|> printfn "%A"

anagram "abcdefgab" "cabbage"
|> printfn "%A"


