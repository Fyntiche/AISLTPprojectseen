using AISLTP.Entities;
using System.Data.Entity;

namespace AISLTP.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection")
        { }

        public DbSet<Sotr> Sotrs { get; set; }
        public DbSet<Lico> Licos { get; set; }
        public DbSet<Pol> Pols { get; set; }
        public DbSet<Nac> Nacs { get; set; }
        public DbSet<Obl> Obls { get; set; }
        public DbSet<Rn> Rns { get; set; }
        public DbSet<Np> Nps { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<LTP> LTPs { get; set; }
        public DbSet<Medcom> Medcoms { get; set; }
        public DbSet<Osnnap> Osnnaps { get; set; }
        public DbSet<Doc> Docs { get; set; }
        public DbSet<Educ> Educs { get; set; }
        public DbSet<Prof> Profs { get; set; }
        public DbSet<Spec> Specs { get; set; }
        public DbSet<Court> Courts { get; set; }
        public DbSet<Vidsv> Vidsvs { get; set; }
        public DbSet<Viddebt> Viddebts { get; set; }
        public DbSet<Otnosh> Otnoshs { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasMany(c => c.Licos)
                .WithMany(s => s.Addresses)
                .Map(t => t.MapLeftKey("AddressID")
                .MapRightKey("LicoID")
                .ToTable("Address_Lico"));
        }
    }
}