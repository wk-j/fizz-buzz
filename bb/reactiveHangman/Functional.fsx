#load "Share.fsx"

open System

let basicTimer, timerEventStream = Share.createTimerAndObservable 1000

timerEventStream
|> Observable.scan (fun count _ -> count + 1) 0
|> Observable.subscribe (fun count -> printfn "timer ticked with count %i" count)

Async.RunSynchronously basicTimer
