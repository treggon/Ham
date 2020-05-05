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
using Ham.DAL;
using Ham.Lib.Models;

namespace HamAPI.Controllers
{
    public class FrequenciesController : ApiController
    {
        private HamContext db = new HamContext();

        // GET: api/Frequencies
        public IQueryable<Frequency> GetFrequencies()
        {
            return db.Frequencies;
        }

        // GET: api/Frequencies/5
        [ResponseType(typeof(Frequency))]
        public async Task<IHttpActionResult> GetFrequency(int id)
        {
            Frequency frequency = await db.Frequencies.FindAsync(id);
            if (frequency == null)
            {
                return NotFound();
            }

            return Ok(frequency);
        }

        // PUT: api/Frequencies/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutFrequency(int id, Frequency frequency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != frequency.ID)
            {
                return BadRequest();
            }

            db.Entry(frequency).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FrequencyExists(id))
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

        // POST: api/Frequencies
        [ResponseType(typeof(Frequency))]
        public async Task<IHttpActionResult> PostFrequency(Frequency frequency)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Frequencies.Add(frequency);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = frequency.ID }, frequency);
        }

        // DELETE: api/Frequencies/5
        [ResponseType(typeof(Frequency))]
        public async Task<IHttpActionResult> DeleteFrequency(int id)
        {
            Frequency frequency = await db.Frequencies.FindAsync(id);
            if (frequency == null)
            {
                return NotFound();
            }

            db.Frequencies.Remove(frequency);
            await db.SaveChangesAsync();

            return Ok(frequency);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool FrequencyExists(int id)
        {
            return db.Frequencies.Count(e => e.ID == id) > 0;
        }
    }
}