using LoginPage.DataAccess;
using LoginPage.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LoginPage.Business
{
    
    public class EventManager
    {
        private EventRepository _manager = new EventRepository();
        
        public Event AddEvent(Event e)
        {
            return _manager.AddEvent(e);
        }
        public Event RemoveEvent(Event e)
        {
            return _manager.RemoveEvent(e);
        }
        public List<Event> GetEvents(Event e)
        {
            return _manager.GetEvents(e.UserId, e.StartDate);
        }
        public List<Event> GetUpcomingEvents(Event ev)
        {
            //ev.StartDate is today's date
            List<Event> eventlist = _manager.GetAllEvents();
            List<Event> upcomingEventList = new List<Event>();
            foreach(Event e in eventlist)
            {
                if(ev.UserId==e.UserId && DateTime.Compare(e.StartDate, ev.StartDate) >= 0) {
                    upcomingEventList.Add(e);
                }
            }
            upcomingEventList = upcomingEventList.OrderBy(x => x.StartDate).ToList();
            if (ev.Importance == 0)//order by date
            {
                
            }
            else if(ev.Importance == 1)//order by importance than date
            {
                
                List<Event> lowImportance = new List<Event>();
                List<Event> mediumImportance = new List<Event>();
                List<Event> highImportance = new List<Event>();
                foreach(Event e in upcomingEventList)
                {
                    if (e.Importance == 0) lowImportance.Add(e);
                    if (e.Importance == 1) mediumImportance.Add(e);
                    if (e.Importance == 2) highImportance.Add(e);
                }
                upcomingEventList.Clear();
                upcomingEventList.AddRange(highImportance);
                upcomingEventList.AddRange(mediumImportance);
                upcomingEventList.AddRange(lowImportance);

            }
                
            
            
            return upcomingEventList;
            
        }
        public Event UpdateEvent(Event e)
        {
            return _manager.UpdateEvent(e); 
        }
    }
}
