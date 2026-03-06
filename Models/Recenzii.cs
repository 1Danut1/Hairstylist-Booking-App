using SiteHairStylist.Models;
using System;
using System.ComponentModel.DataAnnotations;

namespace SiteHairStylist.Models
{
    public class Recenzii
    {
        [Key]
        public int ReviewID { get; set; }
        public int? ServiceID { get; set; }
        public virtual Servicii? Serviciu { get; set; }
        public int Evaluare { get; set; }
        public string? Comentariu { get; set; }
        public DateTime DataPostarii { get; set; }
    }
}
