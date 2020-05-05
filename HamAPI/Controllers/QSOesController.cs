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
    public class QSOesController : ApiController
    {
        private HamContext db = new HamContext();

        // GET: api/QSOes
        public IQueryable<QSO> GetQSOes()
        {
            return db.QSOes;
        }

        // GET: api/QSOes/5
        [ResponseType(typeof(QSO))]
        public async Task<IHttpActionResult> GetQSO(int id)
        {
            QSO qSO = await db.QSOes.FindAsync(id);
            if (qSO == null)
            {
                return NotFound();
            }

            return Ok(qSO);
        }

        // PUT: api/QSOes/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutQSO(int id, QSO qSO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != qSO.ID)
            {
                return BadRequest();
            }

            db.Entry(qSO).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!QSOExists(id))
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

        // POST: api/QSOes
        [ResponseType(typeof(QSO))]
        public async Task<IHttpActionResult> PostQSO(QSO qSO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QSOes.Add(qSO);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = qSO.ID }, qSO);
        }

        // DELETE: api/QSOes/5
        [ResponseType(typeof(QSO))]
        public async Task<IHttpActionResult> DeleteQSO(int id)
        {
            QSO qSO = await db.QSOes.FindAsync(id);
            if (qSO == null)
            {
                return NotFound();
            }

            db.QSOes.Remove(qSO);
            await db.SaveChangesAsync();

            return Ok(qSO);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool QSOExists(int id)
        {
            return db.QSOes.Count(e => e.ID == id) > 0;
        }
    }
}