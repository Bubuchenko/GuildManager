using GuildManager.Data;
using GuildManager.Models;
using GuildManager.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GuildManager.Controllers
{
    public class HomeController : Controller
    {

        public GMContext db = new GMContext();

        public ActionResult Index()
        {

            GuildIndexViewModel vm = new GuildIndexViewModel //<--
            {
                Guilds = db.Guilds.ToList(),
                Players = db.Characters.ToList()
                
            };
            
            return View(vm);
        }
    }
}