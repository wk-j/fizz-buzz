type Member = {
    Id: int
    Name: string
}

let a = [
    { Id = 2; Name = "N2" }
    { Id = 1; Name = "N1" }
]

let b = [
    { Id = 1; Name = "N1" }
    { Id = 2; Name = "N2" }
    { Id = 2; Name = "N2" }
]

let clean =
    List.distinctBy (fun x -> x.Id)
    >> List.sortBy (fun x -> x.Id)

let isEqual = (clean a) = (clean b)

printfn "%A" isEqual