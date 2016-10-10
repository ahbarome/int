using System.Collections.Generic;

namespace INT.Service.DTO.Requests
{
    public class LogDataCollectionRequest : List<LogDataRequest>
    {
        public LogDataCollectionRequest() : base() { }
        public LogDataCollectionRequest(IEnumerable<LogDataRequest> collection) : base(collection) { }
    }
}
