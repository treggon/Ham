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
    public class QSOsController : ApiController
    {
        private HamContext db = new HamContext();

        // GET: api/QSOs
        public IQueryable<QSO> GetQSOs()
        {
            return db.QSOs;
        }

        // GET: api/QSOs/5
        [ResponseType(typeof(QSO))]
        public async Task<IHttpActionResult> GetQSO(int id)
        {
            QSO qSO = await db.QSOs.FindAsync(id);
            if (qSO == null)
            {
                return NotFound();
            }

            return Ok(qSO);
        }

        // PUT: api/QSOs/5
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

        // POST: api/QSOs
        [ResponseType(typeof(QSO))]
        public async Task<IHttpActionResult> PostQSO(QSO qSO)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.QSOs.Add(qSO);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = qSO.ID }, qSO);
        }

        // DELETE: api/QSOs/5
        [ResponseType(typeof(QSO))]
        public async Task<IHttpActionResult> DeleteQSO(int id)
        {
            QSO qSO = await db.QSOs.FindAsync(id);
            if (qSO == null)
            {
                return NotFound();
            }

            db.QSOs.Remove(qSO);
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
            return db.QSOs.Count(e => e.ID == id) > 0;
        }
    }
}