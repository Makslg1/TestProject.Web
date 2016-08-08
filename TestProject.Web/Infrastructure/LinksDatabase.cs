using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestProject.Domain;

namespace TestProject.Web.Infrastructure
{
    public class LinksDatabase:DbContext
    {
        public LinksDatabase():base("DefaultConnection")
        {
        }
        public DbSet<UserProfile> UserProfiles { get; set; }
        public DbSet<Link> Links { get; set; }
    }
}