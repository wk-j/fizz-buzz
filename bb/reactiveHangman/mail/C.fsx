open System
open System.Diagnostics

type Msg =
    | Add of int64
    | GetAndReset of AsyncReplyChannel<int64>

let create() = MailboxProcessor.Start(fun mb ->
    async {
        let mutable state = 0L
        while true do
            let! msg = mb.Receive()
            match msg with
            | Add n -> state <- state + n
            | GetAndReset reply ->
                let was = state
                state <- 0L
                reply.Reply was
    })

let add (mp: MailboxProcessor<Msg>) (n: int64) = mp.Post (Add n)

let getAndReset (mp: MailboxProcessor<Msg>) = mp.PostAndReply GetAndReset

let run numPerThread =
    let timer = Stopwatch.StartNew()
    printf "MailboxProcessor: "
    let actor = create()

    let _ =
        [1..Environment.ProcessorCount]
        |> List.map (fun _ ->
             async { for _ in 1..numPerThread do
                        add actor 100L })
        |> Async.Parallel
        |> Async.RunSynchronously

    let _ = getAndReset actor
    let d = timer.Elapsed
    printf "%d * %8d msgs => %8.0f msgs/s\n"
           Environment.ProcessorCount numPerThread
           (float (Environment.ProcessorCount * numPerThread) / d.TotalSeconds)

for n in [300] do
    run n