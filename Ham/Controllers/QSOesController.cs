using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Ham.DAL;
using Ham.Lib.Models;

namespace Ham.Controllers
{
    public class QSOesController : Controller
    {
        private HamContext db = new HamContext();

        // GET: QSOes
        public async Task<ActionResult> Index()
        {
            var qSOes = db.QSOes.Include(q => q.CallSign).Include(q => q.Contact).Include(q => q.Frequency).Include(q => q.Station);
            return View(await qSOes.ToListAsync());
        }

        // GET: QSOes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QSO qSO = await db.QSOes.FindAsync(id);
            if (qSO == null)
            {
                return HttpNotFound();
            }
            return View(qSO);
        }

        // GET: QSOes/Create
        public ActionResult Create()
        {
            ViewBag.CallSignID = new SelectList(db.CallSigns, "ID", "Name");
            ViewBag.ContactID = new SelectList(db.Contacts, "ID", "Name");
            ViewBag.FrequencyID = new SelectList(db.Frequencies, "ID", "Name");
            ViewBag.StationID = new SelectList(db.Stations, "ID", "Note");
            return View();
        }

        // POST: QSOes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,ContactID,StationID,CallSignID,FrequencyID")] QSO qSO)
        {
            if (ModelState.IsValid)
            {
                db.QSOes.Add(qSO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CallSignID = new SelectList(db.CallSigns, "ID", "Name", qSO.CallSignID);
            ViewBag.ContactID = new SelectList(db.Contacts, "ID", "Name", qSO.ContactID);
            ViewBag.FrequencyID = new SelectList(db.Frequencies, "ID", "Name", qSO.FrequencyID);
            ViewBag.StationID = new SelectList(db.Stations, "ID", "Note", qSO.StationID);
            return View(qSO);
        }

        // GET: QSOes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QSO qSO = await db.QSOes.FindAsync(id);
            if (qSO == null)
            {
                return HttpNotFound();
            }
            ViewBag.CallSignID = new SelectList(db.CallSigns, "ID", "Name", qSO.CallSignID);
            ViewBag.ContactID = new SelectList(db.Contacts, "ID", "Name", qSO.ContactID);
            ViewBag.FrequencyID = new SelectList(db.Frequencies, "ID", "Name", qSO.FrequencyID);
            ViewBag.StationID = new SelectList(db.Stations, "ID", "Note", qSO.StationID);
            return View(qSO);
        }

        // POST: QSOes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,ContactID,StationID,CallSignID,FrequencyID")] QSO qSO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qSO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CallSignID = new SelectList(db.CallSigns, "ID", "Name", qSO.CallSignID);
            ViewBag.ContactID = new SelectList(db.Contacts, "ID", "Name", qSO.ContactID);
            ViewBag.FrequencyID = new SelectList(db.Frequencies, "ID", "Name", qSO.FrequencyID);
            ViewBag.StationID = new SelectList(db.Stations, "ID", "Note", qSO.StationID);
            return View(qSO);
        }

        // GET: QSOes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QSO qSO = await db.QSOes.FindAsync(id);
            if (qSO == null)
            {
                return HttpNotFound();
            }
            return View(qSO);
        }

        // POST: QSOes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            QSO qSO = await db.QSOes.FindAsync(id);
            db.QSOes.Remove(qSO);
            await db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
