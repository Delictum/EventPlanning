using System;

namespace EventPlanning.Mvc.Models.Entities
{
    public class IssuedReward
    {
        public int IssuedRewardId { get; set; }
        public DateTime RemunerationDate { get; set; }
        public double AmountRewardIssued { get; set; }

        public int EventRewardId { get; set; }
        public EventReward EventReward { get; set; }

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }
    }
}