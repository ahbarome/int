namespace INT.Service.DAL.Model
{
    using DTO.Requests;
    using System.Collections.Generic;
    using System.Linq;

    public partial class CurrentDevice
    {
        public static DataDownloadRequest Convert(CurrentDevice device, List<string> toDataBases)
        {
            return new DataDownloadRequest()
            {
                SyncId = device.SyncId,
                FromIpAddress = device.FromIpAddress,
                ToDataBases = toDataBases
            };
        }

        public static DataDownloadCollectionRequest Convert(List<CurrentDevice> devices)
        {
            var result = new DataDownloadCollectionRequest();

            devices.ForEach(device =>
            {
                var devicesWithDataBases =
                    devices.Where(
                        deviceWithDatabases => 
                        deviceWithDatabases.FromIpAddress.Equals(device.FromIpAddress)).ToList();

                var toDatabases = new List<string>();

                devicesWithDataBases.ForEach(
                    deviceWithDatabase => toDatabases.Add(deviceWithDatabase.ToDataBase));

                result.Add(Convert(device, toDatabases));
            });

            return result;
        }
    }
}