using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication9.Models;
using WebApplication9.Interfaces;
using WebApplication9.DAL;

namespace WebApplication9.Repositories
{
    public class PaintingRepositoryPSQL : IPaintingRepository
    {
        private MuseumContext db = new MuseumContext();


        public List<Painting> GetAll()
        {
            return db.Paintings.ToList();
        }

        public Painting Get(int id)
        {
            return db.Paintings.Find(id);
        }

        public int Add(Painting painting)
        {
            db.Paintings.Add(painting);
            db.SaveChanges();

            return painting.Id;
        }

        public Painting Update(Painting painting)
        {
            Painting p = db.Paintings.Find(painting.Id);
            if (p == null)
            {
                return null;
            }
            else
            {
                p = painting;
                db.SaveChanges();
                return painting;
            }
        }

        public bool Delete(int id)
        {
            Painting p = db.Paintings.Find(id);
            if (p == null)
            {
                return false;
            }
            else
            {
                db.Paintings.Remove(p);
                db.SaveChanges();
                return true;
            }

        }
    }
}