using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GuildManager.Models
{
    public class Character
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string FamilyName { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
        public Class Class { get; set; }
        public Faction Faction { get; set; }
        public Boolean IsOnline { get; set; }

        public Membership Membership { get; set; }


    }
    public enum Faction
    {
        Flames,
        IceWind,
        EarthStorm
    }

    public enum Class
    {
        Taoist,
        Trojan,
        Archer,
        Ninja,
        Warrior
    }
}
