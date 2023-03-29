using System;

namespace ConsoleAppIntermediate.CommuncationChannelInterface
{
    //Can send Mail,SMS
    public class SMSServiceChannel : ICommunicationChannel
    {
        public void send(Message message)
        {
            Console.WriteLine("Sending SMS...");
        }
    }
}