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
using WebApplicationApi.Models;

namespace WebApplicationApi.Controllers
{
    public class CaloriasController : ApiController
    {
        private Modelo db = new Modelo();

        // GET: api/Calorias
        public IQueryable<Calorias> GetCalorias()
        {
            return db.Calorias;
        }

        // GET: api/Calorias/5
        [ResponseType(typeof(Calorias))]
        public async Task<IHttpActionResult> GetCalorias(string id)
        {
            Calorias calorias = await db.Calorias.FindAsync(id);
            if (calorias == null)
            {
                return NotFound();
            }

            return Ok(calorias);
        }

        // PUT: api/Calorias/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutCalorias(string id, Calorias calorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != calorias.email)
            {
                return BadRequest();
            }

            db.Entry(calorias).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CaloriasExists(id))
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

        // POST: api/Calorias
        [ResponseType(typeof(Calorias))]
        public async Task<IHttpActionResult> PostCalorias(Calorias calorias)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Calorias.Add(calorias);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (CaloriasExists(calorias.email))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = calorias.email }, calorias);
        }

        // DELETE: api/Calorias/5
        [ResponseType(typeof(Calorias))]
        public async Task<IHttpActionResult> DeleteCalorias(string id)
        {
            Calorias calorias = await db.Calorias.FindAsync(id);
            if (calorias == null)
            {
                return NotFound();
            }

            db.Calorias.Remove(calorias);
            await db.SaveChangesAsync();

            return Ok(calorias);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CaloriasExists(string id)
        {
            return db.Calorias.Count(e => e.email == id) > 0;
        }
    }
}