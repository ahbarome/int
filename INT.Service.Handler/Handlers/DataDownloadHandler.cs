using System;
using INT.Service.Handler.Interfaces;
using Common.Logging;
using INT.Service.DTO.Requests;

namespace INT.Service.Handler.Handlers
{
    public class DataDownloadHandler : IHandler<DataDownloadRequest>
    {
        private readonly ILog LOGGER = null;

        public DataDownloadHandler()
        {
            LOGGER = LogManager.GetLogger(this.GetType());
        }

        public void Handle(DataDownloadRequest request)
        {
            try
            {
                Console.WriteLine(
                    "Request received: {0} {1}", request.FromIpAddress, request.ToDataBase);
            }
            catch (Exception exception)
            {
                LOGGER.Error(exception.Message, exception);
                throw;
            }
           
        }
    }
}
