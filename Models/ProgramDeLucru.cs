using System;
using System.ComponentModel.DataAnnotations;

namespace SiteHairStylist.Models
{
    public class ProgramDeLucru
    {
        [Key]
        public int WorkScheduleID { get; set; }
        public string? ZiuaSaptamanii { get; set; }
        public TimeSpan OraDeschidere { get; set; }
        public TimeSpan OraInchidere { get; set; }
    }
}
