using System.Collections.Generic;
using System.Web.Mvc;
using EventPlanning.Mvc.Models.Entities;

namespace EventPlanning.Mvc.ViewModel
{
    public class EventsListViewModel
    {
        public IEnumerable<Event> Events { get; set; }
        public SelectList EventCategory { get; set; }
    }
}