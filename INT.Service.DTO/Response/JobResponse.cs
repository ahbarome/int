namespace INT.Service.DTO.Response
{
    public class JobResponse
    {
        public string JobName { get; set; }
        public string TriggerName { get; set; }
        public string SchedulerGroup { get; set; }
        public string CronExpression { get; set; }
    }
}
