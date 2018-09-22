System.Console.ReadLine().Split(' ')
|> Array.map System.Double.Parse
|> (fun x -> 100. * (1. - Array.reduce (/) x))
|> printfn "%.2f"