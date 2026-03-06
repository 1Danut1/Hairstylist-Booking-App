using SiteHairStylist.Models;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SiteHairStylist.Models
{
    public class Pret
    {
        [Key]
        public int PriceID { get; set; }
        public int? ServiceID { get; set; }

        [Column(TypeName = "decimal(18, 2)")]
        public decimal? Suma { get; set; }
        public virtual Servicii? Serviciu { get; set; }
    }
}
