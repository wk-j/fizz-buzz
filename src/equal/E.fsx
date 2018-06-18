
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

let (&&&) f g a b = (f a >> g a) b
let clean = (List.distinctBy &&& List.sortBy) (fun x -> x.Id)
let isEqual = (clean a) = (clean b)

printfn "a = b : %A" isEqual