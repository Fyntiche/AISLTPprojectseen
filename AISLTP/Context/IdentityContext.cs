using AISLTP.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AISLTP.Context 
{
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext() : base( "DefaultConnection" )
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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>().HasMany( c => c.Licos )
                .WithMany( s => s.Addresses )
                .Map( t => t.MapLeftKey( "AddressID" )
                 .MapRightKey( "LicoID" )
                 .ToTable( "Address_Lico" ) );
        }
    }
}