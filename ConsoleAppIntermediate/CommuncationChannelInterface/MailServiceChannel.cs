using System;

namespace ConsoleAppIntermediate.CommuncationChannelInterface
{
    public class MailServiceChannel : ICommunicationChannel
    {
        public void send(Message message)
        {
            Console.WriteLine("Sending MAil...");
        }


    }
}