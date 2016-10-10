using System;
using INT.Service.Scheduler.Interfaces;
using INT.Service.DTO.Requests;
using INT.Service.Dispatcher.Interfaces;
using INT.Service.DAL.DataAccess;

namespace INT.Service.Scheduler.Schedulers
{
    public class DataDownloadScheduler : IScheduler
    {
        public IDispatch<DataDownloadRequest> DataDownloadDispatcher { get; set; }

        public void ExecuteTask()
        {
            if (DataDownloadDispatcher != null)
            {
                var DAO = new DAOManager();

                var devicesToMonitor = DAO.GetDevicesToMonitor();

                foreach(var device in devicesToMonitor)
                {
                    DataDownloadDispatcher.SendMessage(device);
                }

                //DataDownloadDispatcher.SendMessage(
                //new DataDownloadRequest
                //{
                //    FromIpAddress = "192.168.0.20",
                //    ToDataBase = @"DUMMY\TEST"
                //});

                Console.WriteLine("Request dispatched!");
            }
        }
    }
}
