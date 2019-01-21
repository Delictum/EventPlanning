namespace EventPlanning.Mvc.Models.Entities
{
    public class EventReward
    {
        public int EventRewardId { get; set; }
        public double AmountRewards { get; set; }
        public double WriteOffInQuantity { get; set; }
        public bool IssuanceOnRequest { get; set; }

        public int EventId { get; set; }
        public Event Event { get; set; }

        public int RewardId { get; set; }
        public Reward Reward { get; set; }
    }
}