using Spring.Context;
using Spring.Context.Support;
using System;
using System.Collections;
using System.Linq;
using System.Messaging;

namespace INT.Service.Host
{
    public class BaseController
    {
        protected IApplicationContext Context { get; set; }

        public virtual void Start()
        {
            Context = ContextRegistry.GetContext();
            CreateQueues();
        }

        public virtual void Stop()
        {
            if(((XmlApplicationContext)Context)!= null)
                ((XmlApplicationContext)Context).Stop();
        }

        /// <summary>
        /// Create automatically queue in the MessageQueue of Windows
        /// </summary>
        private void CreateQueues()
        {
            // Reading the queues
            var queues = Context.GetObjectsOfType(typeof(MessageQueue)).Cast<DictionaryEntry>().Select(x => x.Value).Cast<MessageQueue>();

            foreach (var queue in queues)
            {
                try
                {
                    if (!MessageQueue.Exists(queue.Path))
                    {
                        MessageQueue.Create(queue.Path, true);
                    }
                }
                catch (Exception exception)
                {
                    var strMsg = string.Format("No fue posible realizar la validación de la cola: [{0}] debido a: {1}", queue.Path, exception.Message);
                }
            }
        }
    }
}
