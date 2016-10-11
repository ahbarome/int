using System;
using INT.Service.Scheduler.Interfaces;
using INT.Service.DTO.Requests;
using INT.Service.Dispatcher.Interfaces;
using INT.Service.DAL.DataAccess;
using Common.Logging;

namespace INT.Service.Scheduler.Schedulers
{
    public class DataDownloadScheduler : IScheduler
    {
        private readonly ILog LOGGER = null;

        public IDispatch<DataDownloadRequest> DataDownloadDispatcher { get; set; }

        public DataDownloadScheduler()
        {
            LOGGER = LogManager.GetLogger(this.GetType());
        }

        public void ExecuteTask()
        {
            if (DataDownloadDispatcher != null)
            {
                var DAO = new DAOManager();

                var devicesToMonitor = DAO.GetDevicesToMonitor();

                foreach(var device in devicesToMonitor)
                {
                    DataDownloadDispatcher.SendMessage(device);
#if (DEBUG)
                    LOGGER.Debug(string.Format("Request dispatched: {0}", device));
#endif
                }
            }
        }
    }
}
