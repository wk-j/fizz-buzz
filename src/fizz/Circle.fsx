let circle items = seq { while true do for item in items do yield item }
let fizzs = circle [""; ""; "Fizz"]
let buzzs = circle [""; ""; ""; ""; "Buzz"]
let numbers = Seq.map string (seq { 1 .. System.Int32.MaxValue })
let words = Seq.zip3 fizzs buzzs numbers
            |> Seq.map (fun (f, b, n) -> Seq.max [f + b; n])
let fizzBuzz number = Seq.item (number - 1) words

fizzBuzz 15 |> printfn "%A"