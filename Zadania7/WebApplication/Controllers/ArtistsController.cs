using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using WebApplication9.Interfaces;
using WebApplication9.Services;
using WebApplication9.Models;


namespace WebApplication9.Controllers
{
    public class ArtistsController : ApiController
    {
        private readonly IArtistRepository _artist;
        private readonly ILogger _logger;
 
        public ArtistsController(IArtistRepository artist, ILogger logger)
        {
            _artist = artist;
            _logger = logger;
        }
       
        // GET api/artists
        public IEnumerable<Artist> GetAll()
        {
            _logger.Write("Get for all artists was called", LogLevel.INFO);
            return _artist.GetAll();
        }

        // GET api/artists/id
        public IHttpActionResult Get(int id)
        {
            _logger.Write("Get for artist was called", LogLevel.INFO);
            Artist artist = _artist.Get(id);
            if (artist == null)
            {
                return NotFound();
            }

            return Ok(artist);
        }

        // POST api/artists
        [ResponseType(typeof(Artist))]
        public IHttpActionResult Post(Artist artist)
        {
            _logger.Write("Post for artist was called", LogLevel.INFO);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _artist.Add(artist);

            return CreatedAtRoute("DefaultApi", new { id = artist.Id }, artist);
        }

        // PUT api/artists/id
        [ResponseType(typeof(Artist))]
        public IHttpActionResult Put(int id, Artist artist)
        {
            _logger.Write("Put for artist was called", LogLevel.INFO);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != artist.Id)
            {
                return BadRequest();
            }

            Artist a = _artist.Update(artist);
            if (a == null)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/artists/id
        public IHttpActionResult Delete(int id)
        {
            _logger.Write("Delete for artist was called", LogLevel.INFO);
            if (!_artist.Delete(id))
            {
                return NotFound();
            }

            return Ok();
        }
    }
}
