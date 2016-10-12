namespace INT.Service.DTO.Requests
{
    public class DataDownloadRequest
    {
        public int SyncId { get; set; }
        public string FromIpAddress { get; set; }
        public string ToDataBase { get; set; }

        public override string ToString()
        {
            return string.Format(
                "[ FromIpAddress: '{0}', ToDataBase: '{1}' ]",
                FromIpAddress,
                ToDataBase);
        }
    }
}
