let text = "asdfsgfdsgaskjlewr"
let part = 4

let arrays =
    text
    |> Array.ofSeq
    |> Array.splitInto part
    |> Array.map (System.String)

let joined = String.concat "" arrays

printfn "%A" (text = joined)