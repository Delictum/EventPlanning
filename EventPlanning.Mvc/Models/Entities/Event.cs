using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace EventPlanning.Mvc.Models.Entities
{
    public class Event
    {
        public int EventId { get; set; }
        [Display(Name = "Название")]
        public string EventTitle { get; set; }

        [Display(Name = "Дата проведения")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd'/'MM'/'yyyy hh:mm tt}", ApplyFormatInEditMode = true)]
        public DateTime EventDate { get; set; }

        [Display(Name = "Тип повторения")]
        public RepeatEventType RepeatEventType { get; set; }
        [Display(Name = "Описание")]
        public string EventDescription { get; set; }
        [Display(Name = "Изображение")]
        public byte[] EventImage { get; set; }
        [Display(Name = "Видимость")]
        public bool EventVisible { get; set; }

        [Display(Name = "Категория")]
        public EventCategory EventCategory { get; set; }
        [Display(Name = "Количество групп")]
        public int SplitNumberGroups { get; set; }
        [Display(Name = "Количество участников в грппах")]
        public int SplitNumberParticipants { get; set; }
        [Display(Name = "Максимальное количество участников")]
        public int MaximumNumberParticipants { get; set; }

        [Display(Name = "Сотрудники")]
        public virtual ICollection<Employee> Employees { get; set; }
        public Event()
        {
            Employees = new List<Employee>();
        }
    }
}