using LoginPage.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginPage.DataAccess
{
    public class EventRepository
    {
        private LoginPageDbContext DbContext;
        //private DbSet<User> Dbset;
        
        public Event AddEvent(Event Event)
        {
            using (var LoginPageDbContext = new LoginPageDbContext())
            {
                LoginPageDbContext.Events.Add(Event);
                LoginPageDbContext.SaveChanges();
                return Event;
            }
        }
        public Event RemoveEvent(Event Event)
        {
            using (var LoginPageDbContext = new LoginPageDbContext())
            {
                LoginPageDbContext.Events.Remove(Event);
                LoginPageDbContext.SaveChanges();
                return Event;
            }

        }
        public List<Event> GetEvents(int userId, DateTime date)
        {
            using (var LoginPageDbContext = new LoginPageDbContext())
            {
                var eventList = (LoginPageDbContext.Events.Where(x => x.UserId == userId && x.StartDate.Date == date.Date)).ToList();
                return eventList;
            }
        }
        public List<Event> GetAllEvents()
        {
            using (var LoginPageDbContext = new LoginPageDbContext())
            {
                return LoginPageDbContext.Events.ToList();

            }
        }
        public Event GetEventByEventId(int eventId)
        {
            using (var LoginPageDbContext = new LoginPageDbContext())
            {

                return LoginPageDbContext.Events.FirstOrDefault(x => x.EventId == eventId);

            }
        }
        public Event UpdateEvent(Event e)
        {
            using (var LoginPageDbContext = new LoginPageDbContext())
            {
                Event found = new Event();
                found = GetEventByEventId(e.EventId); //başka özellikler değiştirilebilir
                found.EventName = e.EventName;
                found.Description = e.Description;
                found.StartDate = e.StartDate;
                found.EndDate = e.EndDate;
                LoginPageDbContext.Events.Update(found);
                LoginPageDbContext.SaveChanges();
                return found;
            }
        }

    }
}
