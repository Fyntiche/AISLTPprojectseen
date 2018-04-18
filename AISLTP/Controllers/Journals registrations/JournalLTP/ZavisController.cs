using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AISLTP.Context;
using AISLTP.Entities;

namespace AISLTP.Controllers.Journals_registrations.JournalLTP
{
    public class ZavisController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Zavis
        public async Task<ActionResult> Index()
        {
            var licos = db.Licos.Include(l => l.Nac).Include(l => l.Np).Include(l => l.Obl).Include(l => l.Pol).Include(l => l.Rn);
            return View(await licos.ToListAsync());
        }

        public async Task<ActionResult> Show(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lico lico = await db.Licos.FindAsync(id);
            if (lico == null)
            {
                return HttpNotFound();
            }
            ViewBag.Fam = lico.Fam;
            ViewBag.Ima = lico.Ima;
            ViewBag.Otc = lico.Otc;
            Session["IDLico"] = lico.ID;
            return View(lico);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Show([Bind(Include = "ID,Zav,Prin,Date")] Lico lico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(lico);
        }

        public ActionResult CreateZavis()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateZavis([Bind(Include = "ID,Zav,Prin,Date")] Zavis CreateZavis)
        {
            if (ModelState.IsValid)
            {
                db.Licos.Find(Session["IDLico"]).Zaviss.Add(CreateZavis);

                //db.Addresses.Add(CreateAddress);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(CreateZavis);
        }


        // GET: Zavis/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zavis zavis = await db.Zavis.FindAsync(id);
            if (zavis == null)
            {
                return HttpNotFound();
            }
            return View(zavis);
        }

        // GET: Zavis/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Zavis/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Zav,Prin,Date")] Zavis zavis)
        {
            if (ModelState.IsValid)
            {
                db.Zavis.Add(zavis);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(zavis);
        }

        // GET: Zavis/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zavis zavis = await db.Zavis.FindAsync(id);
            if (zavis == null)
            {
                return HttpNotFound();
            }
            return View(zavis);
        }

        // POST: Zavis/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Zav,Prin,Date")] Zavis zavis)
        {
            if (ModelState.IsValid)
            {
                db.Entry(zavis).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(zavis);
        }

        // GET: Zavis/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Zavis zavis = await db.Zavis.FindAsync(id);
            if (zavis == null)
            {
                return HttpNotFound();
            }
            return View(zavis);
        }

        // POST: Zavis/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Zavis zavis = await db.Zavis.FindAsync(id);
            db.Zavis.Remove(zavis);
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
