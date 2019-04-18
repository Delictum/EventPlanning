using System.ComponentModel.DataAnnotations;

namespace EventPlanning.Mvc.Models.Entities
{
    public class EventReward
    {
        public int EventRewardId { get; set; }
        [Display(Name = "Количество наград")]
        public double AmountRewards { get; set; }
        [Display(Name = "Списывать в количестве")]
        public double WriteOffInQuantity { get; set; }
        [Display(Name = "Подтверждать выдачу")]
        public bool IssuanceOnRequest { get; set; }

        [Display(Name = "Мероприятие")]
        public int EventId { get; set; }
        public Event Event { get; set; }

        [Display(Name = "Награда")]
        public int RewardId { get; set; }
        public Reward Reward { get; set; }
    }
}