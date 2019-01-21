using Quartz;
using Quartz.Impl;

namespace EventPlanning.Mvc.Jobs
{
    public class EmailScheduler
    {
        public static async void Start()
        {
            IScheduler scheduler = await StdSchedulerFactory.GetDefaultScheduler();
            await scheduler.Start();

            IJobDetail job = JobBuilder.Create<EmailSender>().Build();

            ITrigger trigger = TriggerBuilder.Create()  
                .WithIdentity("sendEmailTrigger", "generalizedGroup") 
                .StartNow()                          
                .WithSimpleSchedule(x => x          
                    .WithIntervalInHours(168)        
                    .RepeatForever())               
                .Build();                            

            await scheduler.ScheduleJob(job, trigger); 
        }
    }
}