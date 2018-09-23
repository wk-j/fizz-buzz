type ImperativeTimerCount() =
    let mutable count = 0
    member this.HandleEvent _ =
        count <- count + 1
        printfn "timer ticked with count %i" count

let createTimer timerInterval eventHandler =
    let timer = System.Timers.Timer(float timerInterval)
    timer.AutoReset <- true
    timer.Elapsed.Add eventHandler
    async {
        timer.Start()
        do! Async.Sleep 5000
        timer.Stop()
    }

let handler = new ImperativeTimerCount()
let timerCount1 = createTimer 500 handler.HandleEvent
Async.RunSynchronously timerCount1