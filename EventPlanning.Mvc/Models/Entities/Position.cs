using System.ComponentModel.DataAnnotations;

namespace EventPlanning.Mvc.Models.Entities
{
    public class Position
    {
        public int PositionId { get; set; }
        [Display(Name = "Название должности")]
        public string JobTitle { get; set; }
    }
}