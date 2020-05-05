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
    public class CallSignsController : Controller
    {
        private HamContext db = new HamContext();

        // GET: CallSigns
        public async Task<ActionResult> Index()
        {
            var callSigns = db.CallSigns.Include(c => c.Category);
            return View(await callSigns.ToListAsync());
        }

        // GET: CallSigns/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CallSign callSign = await db.CallSigns.FindAsync(id);
            if (callSign == null)
            {
                return HttpNotFound();
            }
            return View(callSign);
        }

        // GET: CallSigns/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "ID");
            return View();
        }

        // POST: CallSigns/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Name,CategoryID")] CallSign callSign)
        {
            if (ModelState.IsValid)
            {
                db.CallSigns.Add(callSign);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "ID", callSign.CategoryID);
            return View(callSign);
        }

        // GET: CallSigns/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CallSign callSign = await db.CallSigns.FindAsync(id);
            if (callSign == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "ID", callSign.CategoryID);
            return View(callSign);
        }

        // POST: CallSigns/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Name,CategoryID")] CallSign callSign)
        {
            if (ModelState.IsValid)
            {
                db.Entry(callSign).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "ID", "ID", callSign.CategoryID);
            return View(callSign);
        }

        // GET: CallSigns/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CallSign callSign = await db.CallSigns.FindAsync(id);
            if (callSign == null)
            {
                return HttpNotFound();
            }
            return View(callSign);
        }

        // POST: CallSigns/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            CallSign callSign = await db.CallSigns.FindAsync(id);
            db.CallSigns.Remove(callSign);
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
