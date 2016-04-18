using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ClassLibrary1;
using Authors;

namespace RESTWebApplication.Controllers
{
    public class AuthorsController : ApiController
    {
        // GET api/Authors
        public IEnumerable<Author> Get()
        {
            return new AuthorDB().GetAll();
        }

        // GET api/Authors/Id
        public Author Get(int id)
        {
            return new AuthorDB().Get(id);
        }

        // POST api/Authors
        public int Post([FromBody]Author author)
        {
            new AuthorDB().Add(author);
            return author.Id;
        }

        // PUT api/Authors/Id
        public void Put(int id, [FromBody]Author author)
        {
            new AuthorDB().Update(author);
        }

        // DELETE api/Authors/Id
        public void Delete(int id)
        {
            new AuthorDB().Delete(id);
        }
    }
}
