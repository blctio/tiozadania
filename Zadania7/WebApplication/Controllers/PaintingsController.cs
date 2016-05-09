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
    public class PaintingsController : ApiController
    {
        private readonly IPaintingRepository _painting;
        private readonly ILogger _logger;

        public PaintingsController(IPaintingRepository painting, ILogger logger)
        {
            _painting = painting;
            _logger = logger;
        }

        // GET api/paintings
        public IEnumerable<Painting> GetAll()
        {
            _logger.Write("Get for all paintings was called", LogLevel.INFO);
            return _painting.GetAll();
        }

        // GET api/paintings/id
        public IHttpActionResult Get(int id)
        {
            _logger.Write("Get for painting was called", LogLevel.INFO);
            Painting painting = _painting.Get(id);
            if (painting == null)
            {
                return NotFound();
            }

            return Ok(painting);
        }

        // POST api/paintings
        [ResponseType(typeof(Painting))]
        public IHttpActionResult Post(Painting painting)
        {
            _logger.Write("Post for painting was called", LogLevel.INFO);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _painting.Add(painting);

            return CreatedAtRoute("DefaultApi", new { id = painting.Id }, painting);
        }

        // PUT api/paintings/id
        [ResponseType(typeof(Painting))]
        public IHttpActionResult Put(int id, Painting painting)
        {
            _logger.Write("Put for painting was called", LogLevel.INFO);
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != painting.Id)
            {
                return BadRequest();
            }

            Painting p = _painting.Update(painting);
            if (p == null)
            {
                return NotFound();
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // DELETE api/paintings/id
        public IHttpActionResult Delete(int id)
        {
            _logger.Write("Delete for painting was called", LogLevel.INFO);
            if (!_painting.Delete(id))
            {
                return NotFound();
            }

            return Ok();
        }
    }
}