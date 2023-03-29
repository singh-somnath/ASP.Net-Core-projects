using System;

namespace ConsoleAppIntermediate.CommuncationChannelInterface
{
    public class TeamserviceChannel : ICommunicationChannel
    {
        public void send(Message message)
        {
            Console.WriteLine("Message Sending in Teams...");
        }


    }
}