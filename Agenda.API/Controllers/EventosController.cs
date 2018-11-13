using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Agenda.Common.Models;
using Agenda.Domain.Models;

namespace Agenda.API.Controllers
{
    [RoutePrefix("api/eventos")]
    public class EventosController : ApiController
    {
        private DataContext db = new DataContext();

        // GET: api/Eventos
        [Route("all")]
        public IHttpActionResult GetEventos()
        {
            var eventos =  db.Eventos;
            var result = eventos.Select(ev => ev.ToResponse()).ToList();

            return Ok(result);
        }

        // GET: api/Eventos/5
        [ResponseType(typeof(Eventos))]
        public async Task<IHttpActionResult> GetEventos(int id)
        {
            Eventos eventos = await db.Eventos.FindAsync(id);
            if (eventos == null)
            {
                return NotFound();
            }

            return Ok(eventos);
        }

        // PUT: api/Eventos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEventos(int id, Eventos eventos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != eventos.id)
            {
                return BadRequest();
            }

            db.Entry(eventos).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventosExists(id))
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

        // POST: api/Eventos
        [ResponseType(typeof(Eventos))]
        public async Task<IHttpActionResult> PostEventos(Eventos eventos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Eventos.Add(eventos);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = eventos.id }, eventos);
        }

        // DELETE: api/Eventos/5
        [ResponseType(typeof(Eventos))]
        public async Task<IHttpActionResult> DeleteEventos(int id)
        {
            Eventos eventos = await db.Eventos.FindAsync(id);
            if (eventos == null)
            {
                return NotFound();
            }

            db.Eventos.Remove(eventos);
            await db.SaveChangesAsync();

            return Ok(eventos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool EventosExists(int id)
        {
            return db.Eventos.Count(e => e.id == id) > 0;
        }
    }
}