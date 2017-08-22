using GuildManager.Extensions;
using GuildManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GuildManager.ViewModels
{
    public class GuildIndexViewModel
    {
        public List<Guild> Guilds { get; set; }
        public List<Character> Players { get; set; }
        public string TopPlayers
        {
            get
            {
                return Players.OrderByDescending(f => f.Membership.ContributionPoints).Take(3).ToList().ToJson(); //wauw
            }
        }
        public string SerializedGuilds
        {
            get
            {
                return Guilds.ToJson();
            }
        }
    }
}