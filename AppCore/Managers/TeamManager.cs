using AppCore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Managers
{
    public class TeamManager
    {
        private readonly AppCoreContext appcorecontext;

        public TeamManager(AppCoreContext appcorecontext)
        {
            this.appcorecontext = appcorecontext;
        }
        public IQueryable<TeamMember> GetTeam()
        {
            return appcorecontext.TeamMembers.OrderBy(x=>x.DisplayOrder);
        }
    }
}
