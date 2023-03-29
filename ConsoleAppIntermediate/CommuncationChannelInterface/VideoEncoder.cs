using System.Collections.Generic;

namespace ConsoleAppIntermediate.CommuncationChannelInterface
{
    public class VideoEncoder
    {
        private readonly IList<ICommunicationChannel> _communicationChannel;
        public VideoEncoder()
        {
            _communicationChannel = new List<ICommunicationChannel>();
        }

        public void Encode(Video video)
        {
            Message message = new Message();
            foreach (var channel in _communicationChannel)
            {
                channel.send(message);
            }

        }

        public void AddChannel(ICommunicationChannel communcationChannel)
        {
            _communicationChannel.Add(communcationChannel);
        }



    }

}