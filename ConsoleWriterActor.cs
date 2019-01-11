using System;
using Akka.Actor;

namespace WinTailC
{
    class ConsoleWriterActor : UntypedActor
    {
        public ConsoleWriterActor()
        {}

        protected override void OnReceive(object message)
        {
            switch(message)
            {
                case ErrorInput result:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(result.ToString());
                    break;
                case ValidInput result:
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(result.ToString());
                    break;
                default:
                    base.Unhandled(message);
                    break;
            }
            
            Console.ResetColor();
        }
    }
}