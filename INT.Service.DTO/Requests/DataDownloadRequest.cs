using System.Collections.Generic;

namespace INT.Service.DTO.Requests
{
    public class DataDownloadRequest
    {
        public int SyncId { get; set; }
        public string FromIpAddress { get; set; }
        public List<string> ToDataBases { get; set; }

        public override string ToString()
        {
            var databases = string.Join(" , ", ToDataBases);

            return string.Format(
                "[ FromIpAddress: '{0}', ToDataBases: '{1}' ]",
                FromIpAddress,
                databases);
        }
    }
}
