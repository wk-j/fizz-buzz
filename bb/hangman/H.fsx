
let flip f a b = f b a
let hangman word inputs =
    Seq.forall (flip Seq.contains inputs) word

hangman "bigbears" "aeioucdprkljh"
|> printfn "%b"