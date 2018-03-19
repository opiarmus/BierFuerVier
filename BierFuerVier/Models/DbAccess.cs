using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BierFuerVier.Models
{
    public class DbAccess : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Beer> Beer { get; set; }
    }
}