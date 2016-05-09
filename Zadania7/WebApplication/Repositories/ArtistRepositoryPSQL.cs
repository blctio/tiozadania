using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication9.Models;
using WebApplication9.Interfaces;
using WebApplication9.DAL;

namespace WebApplication9.Repositories
{
    public class ArtistRepositoryPSQL : IArtistRepository
    {
        private MuseumContext db = new MuseumContext();


        public List<Artist> GetAll()
        {
            return db.Artists.ToList();
        }

        public Artist Get(int id)
        {
            return db.Artists.Find(id);
        }

        public int Add(Artist artist)
        {
            db.Artists.Add(artist);
            db.SaveChanges();

            return artist.Id;
        }

        public Artist Update(Artist artist)
        {
            Artist a = db.Artists.Find(artist.Id);
            if(a == null)
            {
                return null;
            }
            else
            {
                a = artist;
                db.SaveChanges();
                return artist;
            }
        }

        public bool Delete(int id)
        {
            Artist a = db.Artists.Find(id);
            if(a == null)
            {
                return false;
            }
            else
            {
                db.Artists.Remove(a);
                db.SaveChanges();
                return true;
            }

        }
    }
}