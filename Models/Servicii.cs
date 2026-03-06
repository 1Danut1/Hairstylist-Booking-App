using SiteHairStylist.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SiteHairStylist.Models
{
    public class Servicii
    {
        [Key]
        public int? ServiceID { get; set; }
        public string? Nume { get; set; }
        public string? Descriere { get; set; }
        public int Durata { get; set; }
        public virtual ICollection<Pret>? Preturi { get; set; }
        public virtual ICollection<Programari>? Programari { get; set; }
        public virtual ICollection<Recenzii>? Recenzii { get; set; }
    }
}
