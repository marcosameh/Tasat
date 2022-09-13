using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class TeamMember
    {
        [NotMapped]
        public string PhotoPath
        {
            get
            {
                return "/photos/team/" + Photo;
            }
        }
    }
}
