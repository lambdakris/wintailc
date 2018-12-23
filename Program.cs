using System;
using Akka.Actor;

namespace WinTailC
{
    class Program
    {
        static ActorSystem WinTailSystem;

        static void Main(string[] args)
        {
            WinTailSystem = ActorSystem.Create("WinTailSystem");

            var consoleWriterActor = WinTailSystem.ActorOf(
                Props.Create(() => new ConsoleWriterActor())
            );
            var consoleReaderActor = WinTailSystem.ActorOf(
                Props.Create(() => new ConsoleReaderActor(consoleWriterActor))
            );

            consoleReaderActor.Tell("read");

            Console.WriteLine("Enter some input");

            WinTailSystem.WhenTerminated.Wait();

            Console.WriteLine("Goodbye...");
        }
    }
}
