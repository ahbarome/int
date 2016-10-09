using INT.Service.ZKemkeeper.Entities;
using System.Collections.Generic;

namespace INT.Service.ZKemkeeper.Interfaces
{
    public interface IZKemWrapper
    {
        /// <summary>
        /// Get a static instance of the wrapper
        /// </summary>
        /// <returns>ZKemWrapper instance</returns>
        /// <summary>
        /// Connect to specific device by network using the default port 4370
        /// </summary>
        /// <param name="ipAddress">IP address of the device</param>
        /// <returns>True if the connection was success</returns>
        bool Connect(string ipAddress);

        /// <summary>
        /// Connect to specific device by network
        /// </summary>
        /// <param name="ipAddress">IP address of the device</param>
        /// <param name="port">Port for the connection with the device</param>
        /// <returns>True if the connection was success</returns>
        bool Connect(string ipAddress, int port);

        /// <summary>
        /// Close the connection to the specific device
        /// </summary>
        void Disconnet();

        /// <summary>
        /// Get all the attendance in the connected device
        /// </summary>
        /// <returns>Attendance or log data in the connected device</returns>
        List<LogData> GetGeneralLogData();

        /// <summary>
        /// Get all the attendance in the connected device
        /// </summary>
        /// <param name="disableDevice">Indicate if the device must be disable to adquire the data</param>
        /// <returns>Attendance or log data for the connected device. If was not possible the connection or 
        /// the reading of the device data, this returns null</returns>
        List<LogData> GetGeneralLogData(bool disableDevice);
    }
}
