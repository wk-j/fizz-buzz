using System.Threading;
using System.Threading.Tasks;
using System;

class Program {

    static void ThreadFunc() {
        try {
            Thread.CurrentThread.Abort();
        } catch (ThreadAbortException) {
            Console.WriteLine("First");
        }
    }

    static void Main(String[] args) {
        try {
            try {
                ThreadFunc();
            } catch (ThreadAbortException) {
                Console.WriteLine("Second");
                Thread.ResetAbort();
            }
        } catch (ThreadAbortException) {
            Console.WriteLine("Third");
        }
    }
}

/*
csc 80/02.csx
mono 02.exe
 */
