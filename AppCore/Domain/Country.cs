using System.ComponentModel.DataAnnotations.Schema;

namespace AppCore.Models
{
    public partial class Country
    {
        [NotMapped]
        public string LocalizedName { get; set; }
    }
}
