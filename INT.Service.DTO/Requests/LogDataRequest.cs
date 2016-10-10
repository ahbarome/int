using System;

namespace INT.Service.DTO.Requests
{
    public class LogDataRequest
    {
        public string ServerName { get; set; }

        public string IpAddress { get; set; }

        public string EnrollmentNumber { get; set; }

        public DateTime RegisterDate { get; set; }
    }
}
