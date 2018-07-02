

type Product = {
    Stocked: bool
    Price: int
}

let Price ({ Price = price }) = price
let Stocked ({ Stocked = stocked }) = stocked
let (&&&) o1 o2 a = o1 a && o2 a

let isCheap i = i < 100

let products = [
    { Stocked = true; Price = 80 }
    { Stocked = true; Price = 200 }
]

products |> List.filter(Stocked &&& (Price >> isCheap))