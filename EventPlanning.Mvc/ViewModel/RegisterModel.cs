using EventPlanning.Mvc.Models;
using EventPlanning.Mvc.Models.Entities;

namespace EventPlanning.Mvc.ViewModel
{
    public class RegisterModel
    {
        public Employee Employee { get; set; }
        public FullName FullName { get; set; }
        public RegisterViewModel RegisterViewModel { get; set; }
    }
}