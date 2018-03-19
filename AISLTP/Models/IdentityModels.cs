using AISLTP.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AISLTP.Models
{
    public class IdentityModels
    {
        public class ApplicationDbContext : DbContext
        {
            public ApplicationDbContext() : base( "DefaultConnection" )
            { }
            public DbSet<Sotr> Sotrs { get; set; }
            public DbSet<Lico> Licoes { get; set; }
            public DbSet<Pol> Pols { get; set; }

        }
    }
}