using System;
using System.ComponentModel.DataAnnotations;

namespace EventPlanning.Mvc.Models.Entities
{
    public class IssuedReward
    {
        public int IssuedRewardId { get; set; }
        [Display(Name = "Дата вознаграждения")]
        public DateTime RemunerationDate { get; set; }
        [Display(Name = "Выплачеваемая сумма вознаграждения")]
        public double AmountRewardIssued { get; set; }

        [Display(Name = "Награда мероприятия")]
        public int EventRewardId { get; set; }
        public EventReward EventReward { get; set; }

        [Display(Name = "Сотрудник")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}