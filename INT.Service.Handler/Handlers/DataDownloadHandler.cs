using System;
using INT.Service.Handler.Interfaces;
using Common.Logging;
using INT.Service.DTO.Requests;
using INT.Service.BLL.Interfaces;

namespace INT.Service.Handler.Handlers
{
    public class DataDownloadHandler : IHandler<DataDownloadRequest>
    {
        private readonly ILog LOGGER = null;
        public IProcessor<DataDownloadRequest> Processor { get; set; }

        public DataDownloadHandler()
        {
            LOGGER = LogManager.GetLogger(this.GetType());
        }

        public void Handle(DataDownloadRequest request)
        {
            try
            {
#if (DEBUG)
                LOGGER.Debug(string.Format("Request received: {0}", request));
#endif
                Processor.Execute(request);
            }
            catch (Exception exception)
            {
                LOGGER.Error(exception.Message, exception);
                throw exception;
            }
        }
    }
}
