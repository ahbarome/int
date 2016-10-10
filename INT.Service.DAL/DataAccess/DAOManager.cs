using INT.Service.DAL.Base;
using INT.Service.DAL.Model;
using INT.Service.DTO.Requests;
using INT.Service.DTO.Responses;
using System;
using System.Linq;

namespace INT.Service.DAL.DataAccess
{
    public class DAOManager
    {
        public DAOManager()
        {
        }

        public DataDownloadCollectionRequest GetDevicesToMonitor()
        {
            BaseContext context = new BaseContext();

            var devices = context.Context.CurrentDevice.ToList();

            var response = CurrentDevice.Convert(devices);

            return response;
        }

        public SaveResponse LoadDeviceData(LogDataRequest data)
        {
            BaseContext context = new BaseContext();

            var count = context.Context.LoadDeviceData(data.ServerName, data.IpAddress, data.EnrollmentNumber, data.RegisterDate);

            var result = count > 0 ? true : false;
            
            return new SaveResponse() { IsSaved = result };
        }

        public DateTime GetLastExecutionByIpAddress(string ipAddress)
        {
            BaseContext context = new BaseContext();

            var date = DateTime.MinValue;

            var trace = context.Context.LoadTrace.Where(x => x.IpAddress.Equals(ipAddress)).FirstOrDefault();

            if (trace != null)
            {
                date = trace.LastLoadDate;

                trace.LastLoadDate = DateTime.Now;
            }
            else
            {
                context.Context.LoadTrace.Add(new LoadTrace() { IpAddress = ipAddress, LastLoadDate = DateTime.Now });
            }

            context.Context.SaveChanges();

            return date;
        }
    }
}
