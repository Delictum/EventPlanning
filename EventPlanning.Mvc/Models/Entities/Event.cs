using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventPlanning.Mvc.Models.Entities
{
    public class Event
    {
        public int EventId { get; set; }
        public string EventTitle { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime EventDate { get; set; }

        public RepeatEventType RepeatEventType { get; set; }
        public string EventDescription { get; set; }
        public byte[] EventImage { get; set; }
        public bool EventVisible { get; set; }

        public EventCategory EventCategory { get; set; }
        public int SplitNumberGroups { get; set; }
        public int SplitNumberParticipants { get; set; }
        public int MaximumNumberParticipants { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }
        public Event()
        {
            Employees = new List<Employee>();
        }
    }
}