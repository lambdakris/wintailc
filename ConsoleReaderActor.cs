using System;
using Akka.Actor;

namespace WinTailC
{
    class ConsoleReaderActor : UntypedActor
    {
        IActorRef _inputValidatorRef;

        public ConsoleReaderActor(IActorRef inputValidatorRef)
        {
            _inputValidatorRef = inputValidatorRef;
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
                    _inputValidatorRef.Tell(input);
                    return;
            }

        }
    }
}