using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventPlanning.Mvc.Models.Entities
{
    public class Employee
    {
        public int EmployeeId { get; set; }
        [Display(Name = "ФИО")]
        public int FullNameId { get; set; }
        [Display(Name = "Должность")]
        public int PositionId { get; set; }
        [Display(Name = "Отдел")]
        public int GroupId { get; set; }
        public string AspNetUsersId { get; set; }

        [Display(Name = "День рождения")]
        public DateTime Birthday { get; set; }
        [Display(Name = "Пол")]
        public BiologicalFloor BiologicalFloor { get; set; }
        [Display(Name = "Адрес")]
        public string Adress { get; set; }
        [Display(Name = "Количество детей")]
        public int AmountChildren { get; set; }

        public FullName FullName { get; set; }
        public Position Position { get; set; }
        public Group Group { get; set; }

        [Display(Name = "Мероприятия")]
        public virtual ICollection<Event> Events { get; set; }
        public Employee()
        {
            Events = new List<Event>();
        }
    }
}