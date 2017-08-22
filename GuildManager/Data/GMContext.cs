using GuildManager.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;

namespace GuildManager.Data
{
    public class GMContext : DbContext
    {
        public GMContext() : base("GPContext")
        {

        }

        //Define our database tables
        public DbSet<Character> Characters { get; set; } 
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Guild> Guilds { get; set; }

    }
}
