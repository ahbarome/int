using System;
using INT.Service.Scheduler.Interfaces;
using INT.Service.DTO.Requests;
using INT.Service.Dispatcher.Interfaces;

namespace INT.Service.Scheduler.Schedulers
{
    public class DataDownloadScheduler : IScheduler
    {
        public IDispatch<DataDownloadRequest> DataDownloadDispatcher { get; set; }

        public void ExecuteTask()
        {
            if (DataDownloadDispatcher != null)
            {
                DataDownloadDispatcher.SendMessage(
                new DataDownloadRequest
                {
                    FromIpAddress = "192.168.0.20",
                    ToDataBase = @"DUMMY\TEST"
                });
                Console.WriteLine("Request dispatched!");
            }

        }
    }
}
