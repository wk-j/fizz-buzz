
let [<Literal>] Empty = ""
let fb input =
    [ if input % 3 = 0 then yield "Fizz"
      if input % 5 = 0 then yield "Buzz" ]
    |> String.concat Empty
    |> function | Empty -> string input | fz -> fz

let fb2 input =
  match input % 3, input % 5 with
  | 0, 0 -> "FizzBuzz"
  | 0, _ -> "Fizz"
  | _, 0 -> "Buzz"
  | _ -> string input

fb2 7  |> printfn "%A"
fb2 10 |> printfn "%A"
fb2 15 |> printfn "%A"
