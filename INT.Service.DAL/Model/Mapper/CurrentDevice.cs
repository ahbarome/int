namespace INT.Service.DAL.Model
{
    using DTO.Requests;
    using System.Collections.Generic;

    public partial class CurrentDevice
    {
        public static DataDownloadRequest Convert(CurrentDevice device)
        {
            return new DataDownloadRequest()
            {
                FromIpAddress = device.FromIpAddress,
                ToDataBase = device.ToDataBase
            };
        }

        public static DataDownloadCollectionRequest Convert(List<CurrentDevice> devices)
        {
            var result = new DataDownloadCollectionRequest();

            devices.ForEach(x =>
            {
                result.Add(Convert(x));
            });

            return result;
        }
    }
}