using Microsoft.AspNetCore.Identity;
using System;
using System.ComponentModel.DataAnnotations;

namespace SiteHairStylist.Models
{
    public class Programari
    {
        [Key]
        public int AppointmentID { get; set; }
        public int? ServiceID { get; set; }
        public virtual Servicii? Serviciu { get; set; }
        public DateTime DataOraProgramarii { get; set; }
        public string? Stare { get; set; }

        public string UserId { get; set; }
        public virtual ApplicationUser User { get; set; }
    }
}
