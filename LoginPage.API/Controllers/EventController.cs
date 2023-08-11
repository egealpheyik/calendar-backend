using LoginPage.Business;
using LoginPage.DataAccess;
using LoginPage.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LoginPage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController
    {
        private EventManager _eventManager = new EventManager();
        private EventRepository _repo = new EventRepository();

        [HttpPost("aaa")]
        public Event AddEvent([FromBody]Event e)
        {
            return _eventManager.AddEvent(e);
        }
        [HttpPut]
        public Event RemoveEvent([FromBody]Event e)
        {
            return _eventManager.RemoveEvent(e);
        }
        [HttpGet("test")]
        public List<Event> GetAllEvents()
        {
            return _repo.GetAllEvents();
        }
        [HttpPost]
        public List<Event> GetEvents([FromBody]Event e)
        {
            return _eventManager.GetEvents(e);
        }
        [HttpPost("upcoming")]
        public List<Event> GetUpcomingEvents([FromBody]Event e)
        {
            return _eventManager.GetUpcomingEvents(e);
        }
        [HttpPut("update")]
        public Event UpdateEvent([FromBody]Event e)
        {
            return _eventManager.UpdateEvent(e);
        }

    }
}
