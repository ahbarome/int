using INT.Service.Dispatcher.Interfaces;
using Spring.Messaging.Core;

namespace INT.Service.Dispatcher
{
    public class Dispatch<T> : IDispatch<T>
    {
        public MessageQueueTemplate MsgQueueTemplate { get; set; }

        public void SendMessage(T message)
        {
            MsgQueueTemplate.ConvertAndSend(message);
        }
    }
}
