#nowarn "40"

type Stream<'a>() =
    let event = new Event<'a>()
    member this.Receive = event.Publish
    member this.Send(data: 'a) = event.Trigger(data)

type  Status = InProgress | Win | Lose

type Result(left: int, secret) =
    member val Status =  Status.InProgress with set, get
    member val SelectedLetters = List.empty<char> with set, get
    member val LifeLeft = left with set, get
    member val SecretWordLength = String.length secret with set, get
    member val KnowSecretWord = String.replicate (String.length secret) "_" with set, get

module HR =
    let private findIndexs input c =
        (input: string)
        |> Seq.mapi (fun i x ->  if x = c then Some i else None)
        |> Seq.choose id
        |> Seq.toList

    let reactiveHangman input stream =
        let outputStream = Stream<Result>()
        let r = Result(7, input)
        let disposeable =
            Observable.subscribe(fun s ->
                r.LifeLeft <- r.LifeLeft - 1
                r.SelectedLetters <- r.SelectedLetters @ [s]
                match findIndexs input s, r.LifeLeft > 0 with
                | (indexs, true) ->
                    Seq.iter(fun i ->
                        r.KnowSecretWord <- r.KnowSecretWord.Remove(i, 1).Insert(i, s.ToString())
                        if not (r.KnowSecretWord.Contains "_") then r.Status <- Status.Win
                    ) indexs
                    outputStream.Send r
                | (_, false) ->
                    r.Status <- Status.Lose
                    outputStream.Send r
            ) (stream: Stream<char>).Receive
        (fun x -> Observable.subscribe x outputStream.Receive)

let start case =
    let inputStream = Stream<char>()
    let observable = HR.reactiveHangman "bigbear" inputStream
    let rec disposeable = observable(fun rs ->
        printfn "Status = %A" rs.Status
        printfn "KnowSecretWord = %A" rs.KnowSecretWord
        match rs.Status with
        | Status.Win | Status.Lose ->
            disposeable.Dispose()
        | _ -> ()
    )
    Seq.iter(inputStream.Send) case
    printfn ""

start "bigear"
start "bigbear"
start "bigbeas"