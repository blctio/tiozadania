using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication9.Models;

namespace WebApplication9.DAL
{
    public class MuseumInitializer : System.Data.Entity.DropCreateDatabaseIfModelChanges<MuseumContext>
    {
        protected override void Seed(MuseumContext context)
        {

            var paintings = new List<Painting>
            {
                new Painting() { Title="Painting1", Year = 1800 },
                new Painting() { Title="Painting2", Year = 1850 }
            };
            paintings.ForEach(p => context.Paintings.Add(p));
            context.SaveChanges();

            var artists = new List<Artist>
            {
                new Artist() { ArtistName ="Name1", ArtistSurname = "Surname1" },
                new Artist() { ArtistName ="Name2", ArtistSurname = "Surname2" }
            };
            artists.ForEach(a => context.Artists.Add(a));
            context.SaveChanges();

        }

    }
}