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

            var consoleWriterRef = WinTailSystem.ActorOf(
                Props.Create(() => new ConsoleWriterActor())
            );
            var inputValidatorRef = WinTailSystem.ActorOf(
                Props.Create(() => new InputValidatorActor(consoleWriterRef))
            );
            var consoleReaderRef = WinTailSystem.ActorOf(
                Props.Create(() => new ConsoleReaderActor(inputValidatorRef))
            );

            Console.WriteLine("Enter some input");

            consoleReaderRef.Tell(new ContinueProcessing());

            WinTailSystem.WhenTerminated.Wait();

            Console.WriteLine("Goodbye...");
        }
    }
}
