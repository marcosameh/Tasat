using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCore.Models
{
    public partial class MenuItem
    {
        [NotMapped]
        public string PhotoPath
        {
            get { return  "/photos/menu/"+Photo; }
        }

        [NotMapped]
        public string FormattedPrice
        {
            get { return Price.ToString("N2")+" EGP"; }
        }
    }
}
