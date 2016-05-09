using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication9.Models;
using WebApplication9.Interfaces;
using LiteDB;

namespace WebApplication9.Repositories
{
    public class ArtistRepositoryLiteDB : IArtistRepository
    {
        private readonly string _artistConnection = @"C:\tmp\artists";

        public List<Artist> GetAll()
        {
            using (var db = new LiteDatabase(this._artistConnection))
            {
                var repository = db.GetCollection<Artist>("artists");
                var results = repository.FindAll();

                return results.Select(x => Map(x)).ToList();
            }
        }

        public Artist Get(int id)
        {
            using (var db = new LiteDatabase(this._artistConnection))
            {
                var repository = db.GetCollection<Artist>("artists");
                var result = repository.FindById(id);

                return Map(result);
            }
        }

        public int Add(Artist artist)
        {
            using (var db = new LiteDatabase(this._artistConnection))
            {
                var dbObject = InverseMap(artist);

                var repository = db.GetCollection<Artist>("artists");
                repository.Insert(dbObject);
                return dbObject.Id;
            }
        }

        public Artist Update(Artist artist)
        {
            using (var db = new LiteDatabase(this._artistConnection))
            {
                var dbObject = InverseMap(artist);

                var repository = db.GetCollection<Artist>("artists");
                if (repository.Update(dbObject))
                    return Map(dbObject);
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._artistConnection))
            {
                var repository = db.GetCollection<Artist>("artist");
                return repository.Delete(id);
            }
        }

        internal Artist Map(Artist dbArtist)
        {
            if (dbArtist == null)
                return null;

            return new Artist() { Id = dbArtist.Id, ArtistName = dbArtist.ArtistName, ArtistSurname = dbArtist.ArtistSurname };
        }

        internal Artist InverseMap(Artist artist)
        {
            if (artist == null)
                return null;

            return new Artist(){ Id = artist.Id, ArtistName = artist.ArtistName, ArtistSurname = artist.ArtistSurname };
        }

    }
}