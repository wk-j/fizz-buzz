
//let inline setFreshConsTail cons t = cons.(::).1 <- t
//let inline freshConsNoTail h = h :: (# "ldnull" : 'T list #)

let rec indexedToFreshConsTail cons xs i =
    match xs with
    | [] ->
        setFreshConsTail cons []
    | h::t ->
        let cons2 = freshConsNoTail (i,h)
        setFreshConsTail cons cons2
        indexedToFreshConsTail cons2 t (i+1)

let indexed xs =
    match xs with
    | [] -> []
    | [h] -> [(0,h)]
    | h::t ->
        let cons = freshConsNoTail (0,h)
        indexedToFreshConsTail cons t 1
        cons