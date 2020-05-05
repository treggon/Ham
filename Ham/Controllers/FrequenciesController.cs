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
    public class FrequenciesController : Controller
    {
        private HamContext db = new HamContext();

        // GET: Frequencies
        public async Task<ActionResult> Index()
        {
            return View(await db.Frequencies.ToListAsync());
        }

        // GET: Frequencies/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frequency frequency = await db.Frequencies.FindAsync(id);
            if (frequency == null)
            {
                return HttpNotFound();
            }
            return View(frequency);
        }

        // GET: Frequencies/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Frequencies/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Hz,Name")] Frequency frequency)
        {
            if (ModelState.IsValid)
            {
                db.Frequencies.Add(frequency);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(frequency);
        }

        // GET: Frequencies/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frequency frequency = await db.Frequencies.FindAsync(id);
            if (frequency == null)
            {
                return HttpNotFound();
            }
            return View(frequency);
        }

        // POST: Frequencies/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Hz,Name")] Frequency frequency)
        {
            if (ModelState.IsValid)
            {
                db.Entry(frequency).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(frequency);
        }

        // GET: Frequencies/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Frequency frequency = await db.Frequencies.FindAsync(id);
            if (frequency == null)
            {
                return HttpNotFound();
            }
            return View(frequency);
        }

        // POST: Frequencies/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Frequency frequency = await db.Frequencies.FindAsync(id);
            db.Frequencies.Remove(frequency);
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
