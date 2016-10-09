using INT.Service.ZKemkeeper.Entities;
using INT.Service.ZKemkeeper.Interfaces;
using System;
using System.Collections.Generic;

namespace INT.Service.ZKemkeeper.Wrappers
{
    public class ZKemWrapperStub : IZKemWrapper
    {
        /// <summary>
        /// Connect to specific device by network using the default port 4370
        /// </summary>
        /// <param name="ipAddress">IP address of the device</param>
        /// <returns>True if the connection was success</returns>
        public bool Connect(string ipAddress)
        {
            return true;
        }

        /// <summary>
        /// Connect to specific device by network
        /// </summary>
        /// <param name="ipAddress">IP address of the device</param>
        /// <param name="port">Port for the connection with the device</param>
        /// <returns>True if the connection was success</returns>
        public bool Connect(string ipAddress, int port)
        {
            return true;
        }

        /// <summary>
        /// Close the connection to the specific device
        /// </summary>
        public void Disconnet()
        {
        }

        /// <summary>
        /// Get all the attendance in the connected device
        /// </summary>
        /// <returns>Attendance or log data in the connected device</returns>
        public List<LogData> GetGeneralLogData()
        {
            return GetGeneralLogData(false);
        }

        /// <summary>
        /// Get all the attendance in the connected device
        /// </summary>
        /// <param name="disableDevice">Indicate if the device must be disable to adquire the data</param>
        /// <returns>Attendance or log data for the connected device. If was not possible the connection or 
        /// the reading of the device data, this returns null</returns>
        public List<LogData> GetGeneralLogData(bool disableDevice)
        {
            var registers = new List<LogData>();
            for (int i = 0; i < 100; i++)
            {
                var register = new LogData
                {
                    EnrollmentNumber = (i + 1).ToString(),
                    RegisterDate = DateTime.Now.AddDays(i),
                    VerifyMode = (i + 1),
                    WorkCode = (i + 1)
                };
                registers.Add(register);
            }
            return registers;
        }
    }
}
