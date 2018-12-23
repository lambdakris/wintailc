using System;
using Akka.Actor;

namespace WinTailC
{
    class ConsoleReaderActor : UntypedActor
    {
        IActorRef _consoleWriterActor;

        public ConsoleReaderActor(IActorRef consoleWriterActor)
        {
            _consoleWriterActor = consoleWriterActor;
        }

        protected override void OnReceive(object message)
        {
            var input = Console.ReadLine();

            switch(input.ToLower())
            {
                case "quit":
                case "exit":
                    Context.System.Terminate();
                    return;
                default:
                    _consoleWriterActor.Tell(input);
                    Self.Tell("read");
                    return;
            }

        }
    }
}