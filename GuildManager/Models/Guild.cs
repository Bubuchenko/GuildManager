using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildManager.Models
{
    public class Guild
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int Level { get; set; }
        public int Points { get; set; }

        public virtual List<Membership> Memberships { get; set; }
        
    }
}
