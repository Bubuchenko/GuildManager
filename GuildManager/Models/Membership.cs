using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace GuildManager.Models
{
    public class Membership
    {
        public int ID { get; set; }
        public GuildRank Rank { get; set; }
        public int ContributionPoints { get; set; }
        public DateTime JoinDate { get; set; }
        
        public virtual Guild Guild { get; set; }
        [Required]
        public virtual Character Character{ get; set; }
    }

    public enum GuildRank
    {
        Private,
        Officer,
        Leader
    }
}
