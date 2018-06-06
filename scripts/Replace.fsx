let replaceWith (replaces: (string * string) list) str: string =
    replaces |> List.fold  (fun acc (s,d) -> acc.Replace(s,d))  str

"Hello, world"
|> replaceWith
    [
        "Hello", "Hi"
        "world", "Moon"
    ]
|> printfn "%A"
