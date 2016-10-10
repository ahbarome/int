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
        IZKemWrapper ZKemWrapper { get; set; }
        IValidator<DataDownloadRequest> Validator { get; set; }

        DAOManager DAO = new DAOManager();

        public void Execute(DataDownloadRequest request)
        {
            Validator.Validate(request);

            ZKemWrapper.Connect(request.FromIpAddress);
            var logData = ZKemWrapper.GetGeneralLogData();
            ZKemWrapper.Disconnet();

            var filteredLogData = ApplyFilters(logData, request.FromIpAddress);
            var filteredLogDataDao = LogDataBuilder(filteredLogData, request.ToDataBase);

            Persist(filteredLogDataDao);
        }

        private void Persist(LogDataCollectionRequest filteredLogDataDao)
        {
            foreach(var data in filteredLogDataDao)
            {
                DAO.LoadDeviceData(data);
            }
        }

        private LogDataCollectionRequest LogDataBuilder(List<LogData> filteredLogData, string ipAddress)
        {
            var logData = new LogDataCollectionRequest();

            filteredLogData.ForEach(x =>
            {
                logData.Add(new LogDataRequest()
                {
                    ServerName = ipAddress,
                    EnrollmentNumber = x.EnrollmentNumber,
                    RegisterDate = x.RegisterDate
                });
            });

            return logData;
        }

        private List<LogData> ApplyFilters(List<LogData> logData, string ipAddress)
        {
            var date = DAO.GetLastExecutionByIpAddress(ipAddress);

            if (date.Equals(DateTime.MinValue))
            {
                return logData;
            }

            return logData.Where(x => x.RegisterDate >= date).ToList();
        }
    }
}
