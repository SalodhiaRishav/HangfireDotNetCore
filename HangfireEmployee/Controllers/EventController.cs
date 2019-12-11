namespace HangfireEmployee.Controllers
{
    using System.Collections.Generic;
    using Microsoft.AspNetCore.Mvc;

    using DAL.Repository;
    using HangfireEmployee.Models;

    public class EventController : Controller
    {

        private readonly EventRepository EventRepository;
        public EventController()
        {
            EventRepository = new EventRepository();
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult GetEvents()
        {
            var eventList = EventRepository?.GetEvents();
            var eventDtoList = new List<EventDto>();
            foreach (var @event in eventList)
            {
                var eventDto = new EventDto()
                {
                    Id = @event.Id,
                    Description = @event.EventDescription
                };
                eventDtoList.Add(eventDto);
            }
            return View(eventDtoList);
        }
    }
}