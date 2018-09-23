
let createTimerAndObservable timerInterval =
    let timer = new System.Timers.Timer(float timerInterval)
    timer.AutoReset <- true
    let observable = timer.Elapsed
    let task = async {
        timer.Start()
        do! Async.Sleep 5000
        timer.Stop()
    }
    (task, observable)