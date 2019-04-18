using System.ComponentModel.DataAnnotations;

namespace EventPlanning.Mvc.Models.Entities
{
    public class Group
    {
        public int GroupId { get; set; }
        [Display(Name = "Название отдела")]
        public string GroupName { get; set; }
    }
}