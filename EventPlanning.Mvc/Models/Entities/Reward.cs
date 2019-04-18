using System.ComponentModel.DataAnnotations;

namespace EventPlanning.Mvc.Models.Entities
{
    public class Reward
    {
        public int RewardId { get; set; }
        [Display(Name = "Название награды")]
        public string AwardName { get; set; }
    }
}