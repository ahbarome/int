using INT.Service.BLL.Interfaces;
using INT.Service.DAL.DataAccess;
using INT.Service.DTO.Requests;
using INT.Service.ZKemkeeper.Entities;
using INT.Service.ZKemkeeper.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace INT.Service.BLL.Processors
{
    public class DataDownloadProcessor : IProcessor<DataDownloadRequest>
    {
        public IZKemWrapper ZKemWrapper { get; set; }
        public IValidator<DataDownloadRequest> Validator { get; set; }
        public DAOManager DAO { get; set; }

        public void Execute(DataDownloadRequest request)
        {
            Validator.Validate(request);

            var connected = ZKemWrapper.Connect(request.FromIpAddress);

            if (connected)
            {
                var logData = ZKemWrapper.GetGeneralLogData();
                ZKemWrapper.Disconnet();

                request.ToDataBases.ForEach(databaseToSynchronize =>
                {
                    var filteredLogData = ApplyFilters(logData, request.FromIpAddress, databaseToSynchronize);
                    var filteredLogDataDao =
                        LogDataBuilder(filteredLogData, request.FromIpAddress, databaseToSynchronize);

                    Persist(filteredLogDataDao);
                });
            }
        }

        private void Persist(LogDataCollectionRequest filteredLogDataDao)
        {
            foreach (var data in filteredLogDataDao)
            {
                DAO.LoadDeviceData(data);
            }
        }

        private LogDataCollectionRequest LogDataBuilder(
            List<LogData> filteredLogData, string ipAddress, string server)
        {
            var logData = new LogDataCollectionRequest();

            filteredLogData.ForEach(x =>
            {
                logData.Add(new LogDataRequest()
                {
                    ServerName = server,
                    IpAddress = ipAddress,
                    EnrollmentNumber = x.EnrollmentNumber,
                    RegisterDate = x.RegisterDate
                });
            });

            return logData;
        }

        private List<LogData> ApplyFilters(
            List<LogData> logData, string ipAddress, string serverName)
        {
            var date = DAO.GetLastExecutionByIpAddressAndServerName(ipAddress, serverName);

            if (date.Equals(DateTime.MinValue))
            {
                return logData;
            }

            return logData.Where(x => x.RegisterDate >= date).ToList();
        }
    }
}
