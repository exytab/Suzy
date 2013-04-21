using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
namespace Suzy.BO
{
    [Obsolete("Устарел", true)]
    class OurDB : DbContext
    {
        public DbSet<account> Accounts { get; set; }
        public DbSet<subscriber> Subscribers { get; set; }
        public DbSet<location_area> Location_areas { get; set; }
        public DbSet<avatar> Avatars { get; set; }
    }
}
