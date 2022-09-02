using AppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Managers
{
    public class EventManager
    {
        private readonly AppCoreContext context;

        public EventManager(AppCoreContext context)
        {
            this.context = context;
        }
        public IQueryable<Event> GetEvents()
        {
           return context.Events.Where(x => x.Active.Value).OrderBy(x => x.DisplayOrder);
        }
    }
}
