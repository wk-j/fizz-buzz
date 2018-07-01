type Product = {
    Stocked: bool
    Price: int
}

let everyPred preds input =
    preds |> Seq.fold (fun acc p -> acc && p input) true

let isCheap i = i < 100

let products =
    [ { Stocked = true; Price = 85 }
      { Stocked = true; Price = 200} ]

let Price  ({ Price = price }) = price
let Stocked ({ Stocked = stocked }) = stocked

let cheapInStock =
    products
    |> List.filter (everyPred
              [ Stocked
                Price >> isCheap
    ])

printfn "%A" cheapInStock


