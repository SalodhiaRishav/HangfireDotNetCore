namespace DAL.Repository
{
    using System.Collections.Generic;
    using System.Linq;

    using DAL.Context;
    using DAL.Models;

    public class EventRepository
    {
        public void AddEvent(Event @event)
        {
            using (var context = new HangfireEmployeeDBContext())
            {
                context.Add(@event);
                context.SaveChanges();
            }
        }

        public List<Event> GetEvents()
        {
            using (var context = new HangfireEmployeeDBContext())
            {
                var events = context.Event.ToList();
                return events;
            }
        }
    }
}

