let inline divRem  (D: 't) (d: 't) =
    let q = D / d  in q, D - q * d


divRem 7 3
|> printfn "%A"

divRem 7I 3I
|> printfn "%A"

divRem 7. 3.
|> printfn "%A"