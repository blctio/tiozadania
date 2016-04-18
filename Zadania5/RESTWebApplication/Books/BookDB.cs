using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LiteDB;
using ClassLibrary1;

namespace Books
{
    public class BookDB
    {
        private readonly string _bookConnection = @"C:\tmp\books";

        public List<Book> GetAll()
        {
            using (var db = new LiteDatabase(this._bookConnection))
            {
                var repository = db.GetCollection<Book>("books");
                var results = repository.FindAll();

                return results.ToList();
            }
        }

        public int Add(Book book)
        {
            using (var db = new LiteDatabase(this._bookConnection))
            {
                var repository = db.GetCollection<Book>("books");
                repository.Insert(book);

                return book.Id;
            }
        }

        public Book Get(int id)
        {
            using (var db = new LiteDatabase(this._bookConnection))
            {
                var repository = db.GetCollection<Book>("books");
                var result = repository.FindById(id);
                return result;
            }
        }

        public Book Update(Book book)
        {
            using (var db = new LiteDatabase(this._bookConnection))
            {
                var repository = db.GetCollection<Book>("books");
                if (repository.Update(book))
                    return book;
                else
                    return null;
            }
        }

        public bool Delete(int id)
        {
            using (var db = new LiteDatabase(this._bookConnection))
            {
                var repository = db.GetCollection<Book>("books");
                return repository.Delete(id);
            }
        }

    }
}
