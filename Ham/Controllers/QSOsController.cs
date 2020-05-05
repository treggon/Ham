using System.Data.Entity;
using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using Ham.DAL;
using Ham.Lib.Models;

namespace Ham.Controllers
{
    public class QSOsController : Controller
    {
        private HamContext db = new HamContext();

        // GET: QSOs
        public async Task<ActionResult> Index()
        {
            var QSOs = db.QSOs.Include(q => q.Contact).Include(q => q.Frequency);
            return View(await QSOs.ToListAsync());
        }

        // GET: QSOs/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QSO qSO = await db.QSOs.FindAsync(id);
            if (qSO == null)
            {
                return HttpNotFound();
            }
            return View(qSO);
        }

        // GET: QSOs/Create
        public ActionResult Create()
        {
            ViewBag.CallSignID = new SelectList(db.CallSigns, "ID", "Name");
            ViewBag.ContactID = new SelectList(db.Contacts, "ID", "Name");
            ViewBag.FrequencyID = new SelectList(db.Frequencies, "ID", "Name");
            ViewBag.StationID = new SelectList(db.Stations, "ID", "Note");
            return View();
        }

        // POST: QSOs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Note,ContactID,StationID,CallSignID,FrequencyID")] QSO qSO)
        {
            if (ModelState.IsValid)
            {
                db.QSOs.Add(qSO);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.CallSignID = new SelectList(db.CallSigns, "ID", "Name");
            ViewBag.ContactID = new SelectList(db.Contacts, "ID", "Name");
            ViewBag.FrequencyID = new SelectList(db.Frequencies, "ID", "Name");
            ViewBag.StationID = new SelectList(db.Stations, "ID", "Note");
            return View(qSO);
        }

        // GET: QSOs/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QSO qSO = await db.QSOs.FindAsync(id);
            if (qSO == null)
            {
                return HttpNotFound();
            }
            return View(qSO);
        }

        // POST: QSOs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Note,ContactID,StationID,CallSignID,FrequencyID")] QSO qSO)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qSO).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.ContactID = new SelectList(db.Contacts, "ID", "Name", qSO.ContactID);
            ViewBag.FrequencyID = new SelectList(db.Frequencies, "ID", "Name", qSO.FrequencyID);

            return View(qSO);
        }

        // GET: QSOs/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            QSO qSO = await db.QSOs.FindAsync(id);
            if (qSO == null)
            {
                return HttpNotFound();
            }
            return View(qSO);
        }

        // POST: QSOs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            QSO qSO = await db.QSOs.FindAsync(id);
            db.QSOs.Remove(qSO);
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
