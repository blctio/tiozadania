using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication9.Models;
using WebApplication9.Interfaces;
using LiteDB;

namespace WebApplication9.Repositories
{
    public class PaintingRepositoryLiteDB
    {
        private readonly string _paintingConnection = @"C:\tmp\paintings";

        public List<Painting> GetAll()
        {
            using (var db = new LiteDatabase(this._paintingConnection))
            {
                var repository = db.GetCollection<Painting>("paintings");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public Painting Get(int id)
        {
            using (var db = new LiteDatabase(this._paintingConnection))
            {
                var repository = db.GetCollection<Painting>("paintings");
                var result = repository.FindById(id);

                return Map(result);
            }
        }

        public int Add(Painting painting)
        {
            using (var db = new LiteDatabase(this._paintingConnection))
            {
                var dbObject = InverseMap(painting);

                var repository = db.GetCollection<Painting>("paintings");
                repository.Insert(dbObject);
                return dbObject.Id;
            }
        }

        public Painting Update(Painting painting)
        {
            using (var db = new LiteDatabase(this._paintingConnection))
            {
                var dbObject = InverseMap(painting);

                var repository = db.GetCollection<Painting>("paintings");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._paintingConnection))
            {
                var repository = db.GetCollection<Painting>("paintings");
                return repository.Delete(id);
            }
        }

        internal Painting Map(Painting dbPainting)
        {
            if (dbPainting == null)
                return null;

            return new Painting() { Id = dbPainting.Id, Title = dbPainting.Title, Year = dbPainting.Year };
        }

        internal Painting InverseMap(Painting painting)
        {
            if (painting == null)
                return null;

            return new Painting() { Id = painting.Id, Title = painting.Title, Year = painting.Year };
        }
    }
}