using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Books;
using ClassLibrary1;

namespace RESTWebApplication.Controllers
{
    public class BooksController : ApiController
    {
        // GET api/Books
        public IEnumerable<Book> Get()
        {
            return new BookDB().GetAll();
        }

        // GET api/Books/Id
        public Book Get(int id)
        {
            return new BookDB().Get(id);
        }

        // GET api/Books
        public IEnumerable<Book> Get(string search)
        {
            return new BookDB().GetAll().Where(x => x.BookTitle.Contains(search));
        }

        // POST api/Books
        public int Post([FromBody]Book book)
        {
            new BookDB().Add(book);
            return book.Id;
        }

        // PUT api/Books/Id
        public void Put(int id, [FromBody]Book book)
        {
            new BookDB().Update(book);
        }

        // DELETE api/Books/Id
        public void Delete(int id)
        {
            new BookDB().Delete(id);
        }
    }
}