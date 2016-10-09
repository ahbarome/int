using System;
namespace INT.Service.ZKemkeeper.Entities
{
    public class LogData
    {
        public int Index { get; set; }
        public string EnrollmentNumber { get; set; }
        public int VerifyMode { get; set; }
        public DateTime RegisterDate { get; set; }
        public int WorkCode { get; set; }
    }
}
