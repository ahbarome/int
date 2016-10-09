using System;
using System.Collections.Generic;
using INT.Service.BLL.Interfaces;
using INT.Service.DTO.Requests;
using INT.Service.ZKemkeeper.Entities;
using INT.Service.ZKemkeeper.Interfaces;

namespace INT.Service.BLL.Processors
{
    public class DataDownloadProcessor : IProcessor<DataDownloadRequest>
    {
        IZKemWrapper ZKemWrapper { get; set; }
        IValidator<DataDownloadRequest> Validator { get; set; }

        public void Execute(DataDownloadRequest request)
        {
            Validator.Validate(request);

            ZKemWrapper.Connect(request.FromIpAddress);
            var logData = ZKemWrapper.GetGeneralLogData();
            ZKemWrapper.Disconnet();

            var filteredLogData = ApplyFilters(logData);
            var filteredLogDataDao = LogDataBuilder(filteredLogData);

            Persist(filteredLogDataDao);
        }

        private void Persist(object filteredLogDataDao)
        {
        }

        private object LogDataBuilder(object filteredLogData)
        {
            return new object();
        }

        private object ApplyFilters(List<LogData> logData)
        {
            return new object();
        }
    }
}
