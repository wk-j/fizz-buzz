open System
open System.Threading
open System.Diagnostics

type Utility() =
    static let rand = new Random()
    static member RandomSleep() =
        let ms = rand.Next(1, 10)
        Thread.Sleep ms

type LockedCouter() =
    static let _lock = new Object()
    static let mutable count = 0
    static let mutable sum = 0

    static let updateState i =
        sum <- sum + 1
        count <- count + 1
        printfn "Count is: %i. Sum is: %i" count sum
        Utility.RandomSleep()

    static member Add i =
        let stopwatch = new Stopwatch()
        stopwatch.Start()

        lock _lock (fun () ->
            stopwatch.Stop()
            printfn "Client watched %i" stopwatch.ElapsedMilliseconds
            updateState i
        )

LockedCouter.Add 4
LockedCouter.Add 5