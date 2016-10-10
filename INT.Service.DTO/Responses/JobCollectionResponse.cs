namespace INT.Service.DTO.Responses
{
    using System.Collections.Generic;
    public class JobCollectionResponse : List<JobResponse>
    {
        public JobCollectionResponse() : base() { }
        public JobCollectionResponse(IEnumerable<JobResponse> collection) : base(collection) { }
    }
}
