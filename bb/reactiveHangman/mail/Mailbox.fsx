open System.Drawing.Printing
let printerAgent = MailboxProcessor.Start(fun inbox ->
    let rec messageLoop() = async {
        let! msg = inbox.Receive()
        printfn "message is: %s" msg
        return! messageLoop()
    }
    messageLoop()
)

printerAgent.Post "Hello"
printerAgent.Post "Hello again"
printerAgent.Post "Hello a third time"