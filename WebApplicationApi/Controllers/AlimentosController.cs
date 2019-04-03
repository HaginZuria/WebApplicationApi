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
    public class AlimentosController : ApiController
    {
        private Modelo db = new Modelo();

        // GET: api/Alimentos
        public IQueryable<Alimentos> GetAlimentos()
        {
            return db.Alimentos;
        }

        // GET: api/Alimentos/5
        [ResponseType(typeof(Alimentos))]
        public async Task<IHttpActionResult> GetAlimentos(int id)
        {
            Alimentos alimentos = await db.Alimentos.FindAsync(id);
            if (alimentos == null)
            {
                return NotFound();
            }

            return Ok(alimentos);
        }

        // PUT: api/Alimentos/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutAlimentos(int id, Alimentos alimentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != alimentos.codigo)
            {
                return BadRequest();
            }

            db.Entry(alimentos).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AlimentosExists(id))
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

        //[HttpGet]
        //[ResponseType(typeof(Alimentos))]
        //[Route("api/alimentos/obtenerAlimento")]
        //public IHttpActionResult GetobtenerAlimento(string email, string password)
        //{
        //    Alimentos alimento = db.Alimentos.Where(x => x.email == email && x.password == password).FirstOrDefault();
        //    if (alimento == null)
        //    {
        //        return BadRequest();
        //    }
        //    else
        //    {
        //        alimento.password = null;
        //        return Ok(alimento);
        //    }


        //}

        // POST: api/Alimentos
        [ResponseType(typeof(Alimentos))]
        public async Task<IHttpActionResult> PostAlimentos(Alimentos alimentos)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Alimentos.Add(alimentos);

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (AlimentosExists(alimentos.codigo))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = alimentos.codigo }, alimentos);
        }

        // DELETE: api/Alimentos/5
        [ResponseType(typeof(Alimentos))]
        public async Task<IHttpActionResult> DeleteAlimentos(int id)
        {
            Alimentos alimentos = await db.Alimentos.FindAsync(id);
            if (alimentos == null)
            {
                return NotFound();
            }

            db.Alimentos.Remove(alimentos);
            await db.SaveChangesAsync();

            return Ok(alimentos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AlimentosExists(int id)
        {
            return db.Alimentos.Count(e => e.codigo == id) > 0;
        }
    }
}