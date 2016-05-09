using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    public class GamesInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<GamesContext>
    {
        protected override void Seed(GamesContext context)
        {
            var games = new List<Game>
            {
                new Game() {Title = "title1", CreatorCompany = "CC1", Year = 2015, AgeRate = 16 },
                new Game() {Title = "title2", CreatorCompany = "CC2", Year = 2014, AgeRate = 16 },
                new Game() {Title = "title3", CreatorCompany = "CC3", Year = 2013, AgeRate = 16 },
                new Game() {Title = "title4", CreatorCompany = "CC4", Year = 2012, AgeRate = 16 },
                new Game() {Title = "title5", CreatorCompany = "CC5", Year = 2011, AgeRate = 16 },
                new Game() {Title = "title6", CreatorCompany = "CC6", Year = 2010, AgeRate = 16 },
            };
            games.ForEach(s => context.Games.Add(s));
            context.SaveChanges();

            var stores = new List<Store>
            {
                new Store() {Name = "name1", Address = "address1"},
                new Store() {Name = "name2", Address = "address2"},
                new Store() {Name = "name3", Address = "address3"},
                new Store() {Name = "name4", Address = "address4"},
                new Store() {Name = "name5", Address = "address5"},
                new Store() {Name = "name6", Address = "address6"},
            };
            stores.ForEach(a => context.Stores.Add(a));
            context.SaveChanges();
        }
    }
}
