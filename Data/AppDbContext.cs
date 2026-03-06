using Microsoft.EntityFrameworkCore;
using SiteHairStylist.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace SiteHairStylist.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Servicii> Servicii { get; set; }
        public DbSet<Pret> Pret { get; set; }
        public DbSet<Programari> Programari { get; set; }
        public DbSet<ProgramDeLucru> ProgramDeLucru { get; set; }
        public DbSet<Recenzii> Recenzii { get; set; }
        public DbSet<Inregistrare> Inregistrare { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<IdentityUserLogin<int>>().HasKey(p => new { p.LoginProvider, p.ProviderKey });
            modelBuilder.Entity<IdentityUserLogin<int>>().Property(p => p.LoginProvider).HasMaxLength(85);
            modelBuilder.Entity<IdentityUserLogin<int>>().Property(p => p.ProviderKey).HasMaxLength(85);

            modelBuilder.Entity<Programari>()
            .HasOne(p => p.User)
            .WithMany(u => u.Programari)
            .HasForeignKey(p => p.UserId);
        }
    }
}
