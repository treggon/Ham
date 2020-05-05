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
    public class StationsController : Controller
    {
        private HamContext db = new HamContext();

        // GET: Stations
        public async Task<ActionResult> Index()
        {
            var stations = db.Stations.Include(s => s.CallSign);
            return View(await stations.ToListAsync());
        }

        // GET: Stations/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station station = await db.Stations.FindAsync(id);
            if (station == null)
            {
                return HttpNotFound();
            }
            return View(station);
        }

        // GET: Stations/Create
        public ActionResult Create()
        {
            ViewBag.CallSignID = new SelectList(db.CallSigns, "ID", "Name");
            return View();
        }

        // POST: Stations/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Note,Power,CallSignID")] Station station)
        {
            if (ModelState.IsValid)
            {
                db.Stations.Add(station);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CallSignID = new SelectList(db.CallSigns, "ID", "Name", station.CallSignID);
            return View(station);
        }

        // GET: Stations/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station station = await db.Stations.FindAsync(id);
            if (station == null)
            {
                return HttpNotFound();
            }
            ViewBag.CallSignID = new SelectList(db.CallSigns, "ID", "Name", station.CallSignID);
            return View(station);
        }

        // POST: Stations/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Note,Power,CallSignID")] Station station)
        {
            if (ModelState.IsValid)
            {
                db.Entry(station).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CallSignID = new SelectList(db.CallSigns, "ID", "Name", station.CallSignID);
            return View(station);
        }

        // GET: Stations/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Station station = await db.Stations.FindAsync(id);
            if (station == null)
            {
                return HttpNotFound();
            }
            return View(station);
        }

        // POST: Stations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Station station = await db.Stations.FindAsync(id);
            db.Stations.Remove(station);
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
