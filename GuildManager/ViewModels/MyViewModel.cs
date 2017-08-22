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

        public string SerializedGuilds
        {
            get
            {
                return Guilds.ToJson();
            }
        }
    }
}