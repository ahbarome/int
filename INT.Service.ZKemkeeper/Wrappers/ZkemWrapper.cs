using INT.Service.ZKemkeeper.Conveters;
using INT.Service.ZKemkeeper.Entities;
using INT.Service.ZKemkeeper.Interfaces;
using System;
using System.Collections.Generic;
using zkemkeeper;

namespace INT.Service.ZKemkeeper.Wrappers
{
    public class ZKemWrapper : IZKemWrapper
    {
        /// <summary>
        /// Create Standalone SDK class dynamicly.
        /// </summary>
        private CZKEMClass zkemkeeper;

        /// <summary>
        /// Indicate if the connection was stablish or not
        /// </summary>
        private bool _isConnected;

        /// <summary>
        /// The serial number of the device. After connecting the device ,this value will be changed.
        /// </summary>
        private int _iMachineNumber = 1;

        /// <summary>
        /// Static instance to create Standalone SDK class dynamicly.
        /// </summary>
        private static ZKemWrapper _instance;

        /// <summary>
        /// Get a static instance of the wrapper
        /// </summary>
        /// <returns>ZKemWrapper instance</returns>
        public ZKemWrapper Instance()
        {
            if (_instance == null)
            {
                _instance = new ZKemWrapper();
            }
            return _instance;
        }

        /// <summary>
        /// Builder of the class
        /// </summary>
        public ZKemWrapper()
        {
            zkemkeeper = new CZKEMClass();
        }

        /// <summary>
        /// Connect to specific device by network using the default port 4370
        /// </summary>
        /// <param name="ipAddress">IP address of the device</param>
        /// <returns>True if the connection was success</returns>
        public bool Connect(string ipAddress)
        {
            return Connect(ipAddress, 4370);
        }

        /// <summary>
        /// Connect to specific device by network
        /// </summary>
        /// <param name="ipAddress">IP address of the device</param>
        /// <param name="port">Port for the connection with the device</param>
        /// <returns>True if the connection was success</returns>
        public bool Connect(string ipAddress, int port)
        {
            _isConnected = zkemkeeper.Connect_Net(ipAddress, port);
            return _isConnected;
        }

        /// <summary>
        /// Close the connection to the specific device
        /// </summary>
        public void Disconnet()
        {
            if (_isConnected)
                zkemkeeper.Disconnect();
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
            if (_isConnected)
            {
                string sdwEnrollNumber = "";
                int idwVerifyMode = 0;
                int idwInOutMode = 0;
                int idwYear = 0;
                int idwMonth = 0;
                int idwDay = 0;
                int idwHour = 0;
                int idwMinute = 0;
                int idwSecond = 0;
                int idwWorkcode = 0;

                int idwErrorCode = 0;

                var registers = new List<LogData>();

                zkemkeeper.EnableDevice(_iMachineNumber, !disableDevice);//disable the device
                if (zkemkeeper.ReadGeneralLogData(_iMachineNumber))//read all the attendance records to the memory
                {
                    while (
                        zkemkeeper.SSR_GetGeneralLogData(
                            _iMachineNumber,
                            out sdwEnrollNumber,
                            out idwVerifyMode,
                            out idwInOutMode,
                            out idwYear,
                            out idwMonth,
                            out idwDay,
                            out idwHour,
                            out idwMinute,
                            out idwSecond,
                            ref idwWorkcode))//get records from the memory
                    {
                        var register = new LogData
                        {
                            EnrollmentNumber = sdwEnrollNumber,
                            VerifyMode = idwVerifyMode,
                            RegisterDate =
                                ZKemDateConverter.ConvertToDate(
                                    idwYear, idwMonth, idwDay, idwHour, idwMinute, idwSecond),
                            WorkCode = idwWorkcode
                        };
                        registers.Add(register);
                    }
                }
                else
                {
                    zkemkeeper.GetLastError(ref idwErrorCode);
                    if (idwErrorCode != 0)
                    {
                        throw new Exception("Reading data from terminal failed, ErrorCode: " + idwErrorCode.ToString());
                    }
                    else
                    {
                        throw new Exception("No data from terminal returns!");
                    }
                }
                zkemkeeper.EnableDevice(_iMachineNumber, disableDevice);//enable the device
                return registers;
            }
            return null;
        }
    }
}
