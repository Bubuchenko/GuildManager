using GuildManager.Models;
using RandomNameGeneratorLibrary;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Threading.Tasks;

namespace GuildManager.Data
{
    public class GMContext : DbContext
    {
        public GMContext() : base("GPContext")
        {
            Database.SetInitializer(new GMontextInitializer());
        }

        //Define our database tables
        public DbSet<Character> Characters { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Guild> Guilds { get; set; }

    }

    public class GMontextInitializer : CreateDatabaseIfNotExists<GMContext>
    {
        static Random random = new Random();
        PersonNameGenerator personGenerator = new PersonNameGenerator();

        protected override void Seed(GMContext context)
        {
            string[] GuildNames = File.ReadAllLines("C:\\GuildNames.txt");


            //Create random guilds
            for (int i = 0; i < GuildNames.Length; i++)
            {
                context.Guilds.Add(new Guild()
                {
                    Name = GuildNames[i],
                    Level = random.Next(0, 100),
                    Points = random.Next(100, 10000000)
                });
            }

            //Create 400 random characters
            for (int i = 0; i < 400; i++)
            {
                context.Characters.Add(new Character()
                {
                    Class = RandomEnumValue<Class>(),
                    Faction = RandomEnumValue<Faction>(),
                    FamilyName = personGenerator.GenerateRandomLastName(),
                    IsOnline = false,
                    Gold = random.Next(0, int.MaxValue),
                    Level = random.Next(1, 70),
                    Name = personGenerator.GenerateRandomFirstName()
                });
            }

            context.SaveChanges();

            //Assign each character to a random guild
            foreach (Character character in context.Characters)
            {
                int randomGuildID = random.Next(1, context.Guilds.Count() - 1);
                context.Memberships.Add(new Membership()
                {
                    Character = character,
                    Guild = context.Guilds.FirstOrDefault(f => f.ID == randomGuildID),
                    Rank = RandomEnumValue<GuildRank>(),
                    ContributionPoints = random.Next(0, 10000000),
                    JoinDate = DateTime.Now
                });
            }

                context.SaveChanges();
                base.Seed(context);
        }
        private static T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(random.Next(v.Length));
        }
    }
}
