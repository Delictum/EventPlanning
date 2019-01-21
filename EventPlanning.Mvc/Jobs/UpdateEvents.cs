using System;
using System.Data.Entity;
using System.Linq;
using EventPlanning.Mvc.Models.Entities;
using Quartz;
using System.Threading.Tasks;

namespace EventPlanning.Mvc.Jobs
{
    public class UpdateEvents : IJob
    {
        public async Task Execute(IJobExecutionContext context)
        {
            using (var db = new EventPlanningContext())
            {
                var events = await db.Events.Where(e => e.EventDate < DateTime.Now).ToListAsync();

                foreach (var @event in events)
                {
                    @event.Employees.Clear();

                    DateTime newDateTime;
                    switch (@event.RepeatEventType)
                    {
                        case RepeatEventType.OneTime:
                        {
                            @event.EventVisible = false;
                            break;
                        }
                        case RepeatEventType.Daily:
                        {
                            newDateTime = @event.EventDate.AddDays(1);
                            @event.EventDate = newDateTime;
                            break;
                        }
                        case RepeatEventType.Weekly:
                        {
                            newDateTime = @event.EventDate.AddDays(7);
                            @event.EventDate = newDateTime;
                            break;
                        }
                        case RepeatEventType.Monthly:
                        {
                            newDateTime = @event.EventDate.AddMonths(1);
                            @event.EventDate = newDateTime;
                            break;
                        }
                        case RepeatEventType.Annual:
                        {
                            newDateTime = @event.EventDate.AddYears(1);
                            @event.EventDate = newDateTime;
                            @event.EventVisible = false;
                            break;
                        }
                        default:
                            throw new ArgumentOutOfRangeException();
                    }

                    db.Entry(@event).State = EntityState.Modified;
                }

                events = await db.Events.Where(e => e.EventDate > DateTime.Now && e.RepeatEventType == RepeatEventType.Annual).ToListAsync();

                foreach (var @event in events)
                {
                    @event.EventVisible = true;
                    db.Entry(@event).State = EntityState.Modified;
                }

                await db.SaveChangesAsync();
            }
        }
    }
}