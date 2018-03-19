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
            {
            }
            public static ApplicationDbContext Create()
            {
                return new ApplicationDbContext();
            }
            public DbSet<Sotr> Sotrs { get; set; }
            public DbSet<Lico> Licos { get; set; }
        }
    }
}