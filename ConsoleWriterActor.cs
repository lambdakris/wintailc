using System;
using Akka.Actor;

namespace WinTailC
{
    class ConsoleWriterActor : UntypedActor
    {
        public ConsoleWriterActor()
        {

        }

        protected override void OnReceive(object message)
        {
            switch(message)
            {
                case String s when string.IsNullOrWhiteSpace(s):
                    Console.WriteLine("Your input had no characters");
                    break;
                case String s when s.Length % 2 == 0:
                    Console.WriteLine("Your input has an even number of characters");
                    break;
                default:
                    Console.WriteLine("Your input has an odd number of characters");
                    break;
            }
        }
    }
}