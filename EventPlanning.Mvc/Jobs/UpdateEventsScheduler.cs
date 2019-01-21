using Quartz;
using Quartz.Impl;

namespace EventPlanning.Mvc.Jobs
{
    public class UpdateEventsScheduler
    {
        public static async void Start()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<UpdateEvents>().Build();

            ITrigger trigger = TriggerBuilder.Create()
                .WithIdentity("updateEventsTrigger", "generalizedGroup")
                .StartNow()                           
                .WithSimpleSchedule(x => x          
                    .WithIntervalInHours(1)         
                    .RepeatForever())                  
                .Build();                            

            await scheduler.ScheduleJob(job, trigger);  
        }
    }
}