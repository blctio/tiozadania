using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using ClassLibrary1;


namespace Authors
{
    public class AuthorDB
    {
        private readonly string _authorConnection = @"C:\tmp\authors";

        public List<Author> GetAll()
        {
            using (var db = new LiteDatabase(this._authorConnection))
            {
                var repository = db.GetCollection<Author>("authors");
                var results = repository.FindAll();

                return results.ToList();
            }
        }

        public int Add(Author author)
        {
            using (var db = new LiteDatabase(this._authorConnection))
            {
                var repository = db.GetCollection<Author>("authors");
                repository.Insert(author);

                return author.Id;
            }
        }

        public Author Get(int id)
        {
            using (var db = new LiteDatabase(this._authorConnection))
            {
                var repository = db.GetCollection<Author>("authors");
                var result = repository.FindById(id);
                return result;
            }
        }


        public Author Update(Author author)
        {
            using (var db = new LiteDatabase(this._authorConnection))
            {
                var repository = db.GetCollection<Author>("authors");
                if (repository.Update(author))
                    return author;
                else
                    return null;
            }
        }


        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._authorConnection))
            {
                var repository = db.GetCollection<Author>("authors");
                return repository.Delete(id);
            }
        }
    }
}
