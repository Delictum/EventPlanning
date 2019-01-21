using System;
using System.Collections.Generic;

namespace EventPlanning.Mvc.Models.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        public int FullNameId { get; set; }
        public int PositionId { get; set; }
        public int GroupId { get; set; }
        public string AspNetUsersId { get; set; }

        public DateTime Birthday { get; set; }
        public BiologicalFloor BiologicalFloor { get; set; }
        public string Adress { get; set; }
        public int AmountChildren { get; set; }

        public FullName FullName { get; set; }
        public Position Position { get; set; }
        public Group Group { get; set; }

        public virtual ICollection<Event> Events { get; set; }
        public Employee()
        {
            Events = new List<Event>();
        }
    }
}