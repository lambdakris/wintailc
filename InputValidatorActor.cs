using System;
using Akka.Actor;

namespace WinTailC {
    public class InputValidatorActor : UntypedActor {
        IActorRef _consoleWriterActor;

        public InputValidatorActor(IActorRef consoleWriterActor) {
            _consoleWriterActor = consoleWriterActor;
        }

        protected override void OnReceive(object message) {
            switch (message) {
                case String input when string.IsNullOrEmpty(input):
                    _consoleWriterActor.Tell(new EmptyInput("Your input had no characters"));
                    break;
                case String input when input.Length % 2 == 0:
                    _consoleWriterActor.Tell(new ValidInput("Your input had an even number of characters"));
                    break;
                case String input when input.Length % 2 != 0:
                    _consoleWriterActor.Tell(new InvalidInput("Your input had an odd number of characters"));
                    break;
                default:
                    base.Unhandled(message);
                    break;
            }
            base.Sender.Tell(new ContinueProcessing());
        }
    }
}