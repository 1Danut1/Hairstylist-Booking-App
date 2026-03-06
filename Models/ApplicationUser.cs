using Microsoft.AspNetCore.Identity;

namespace SiteHairStylist.Models
{
	public class ApplicationUser : IdentityUser
	{
		public string Firstname { get; set; }
		public string Lastname { get; set; }

        public virtual ICollection<Programari> Programari { get; set; }

    }
}
