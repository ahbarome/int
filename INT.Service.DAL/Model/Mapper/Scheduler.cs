namespace INT.Service.DAL.Model
{
    using INT.Service.DTO.Responses;
    public partial class Scheduler
    {
        public static JobResponse Convert(Scheduler scheduler)
        {
            return new JobResponse()
            {
                JobName = scheduler.JobName,
                SchedulerGroup = scheduler.ScheduleGroup,
                TriggerName = scheduler.TriggerName,
                CronExpression = ""
            };
        }
    }
}
