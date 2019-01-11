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
using WebApi.Models;

namespace WebApi.Controllers
{
    public class notasController : ApiController
    {
        private Model1 db = new Model1();

        // GET: api/notas
        public IQueryable<notas> Getnotas()
        {
            return db.notas;
        }

        // GET: api/notas/5
        [ResponseType(typeof(notas))]
        public IHttpActionResult Getnotas(int id)
        {
            notas notas = db.notas.Find(id);
            if (notas == null)
            {
                return NotFound();
            }

            return Ok(notas);
        }

        // PUT: api/notas/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putnotas(int id, notas notas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != notas.id)
            {
                return BadRequest();
            }

            db.Entry(notas).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!notasExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/notas
        [ResponseType(typeof(notas))]
        public IHttpActionResult Postnotas(notas notas)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.notas.Add(notas);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = notas.id }, notas);
        }

        // DELETE: api/notas/5
        [ResponseType(typeof(notas))]
        public IHttpActionResult Deletenotas(int id)
        {
            notas notas = db.notas.Find(id);
            if (notas == null)
            {
                return NotFound();
            }

            db.notas.Remove(notas);
            db.SaveChanges();

            return Ok(notas);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool notasExists(int id)
        {
            return db.notas.Count(e => e.id == id) > 0;
        }
    }
}