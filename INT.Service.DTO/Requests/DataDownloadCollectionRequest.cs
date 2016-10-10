namespace INT.Service.DTO.Requests
{
    using System.Collections.Generic;
    public class DataDownloadCollectionRequest : List<DataDownloadRequest>
    {
        public DataDownloadCollectionRequest() : base() { }
        public DataDownloadCollectionRequest(IEnumerable<DataDownloadRequest> collection) : base(collection) { }
    }
}
