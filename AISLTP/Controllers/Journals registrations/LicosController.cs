using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AISLTP.Entities;
using AISLTP.Models;
using static AISLTP.Models.IdentityModels;

namespace AISLTP.Controllers.Journals_registrations
{
    public class LicosController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Licos
        public async Task<ActionResult> Index()
        {
            var licoes = db.Licoes.Include( l => l.Pol);
            return View(await licoes.ToListAsync());
        }

        // GET: Licos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lico lico = await db.Licoes.FindAsync(id);
            if (lico == null)
            {
                return HttpNotFound();
            }
            return View(lico);
        }

        // GET: Licos/Create
        public ActionResult Create()
        {
            ViewBag.PolID = new SelectList(db.Pols, "ID", "Txt");
            return View();
        }

        // POST: Licos/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "ID,Fam,Ima,Otc,Dr,PolID,Pasport,Nac,Obl,Rn,Np,Vneshnost,Prim")] Lico lico)
        {
            if (ModelState.IsValid)
            {
                db.Licoes.Add(lico);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.PolID = new SelectList(db.Pols, "ID", "Txt", lico.PolID);
            return View(lico);
        }

        // GET: Licos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lico lico = await db.Licoes.FindAsync(id);
            if (lico == null)
            {
                return HttpNotFound();
            }
            ViewBag.PolID = new SelectList(db.Pols, "ID", "Txt", lico.PolID);
            return View(lico);
        }

        // POST: Licos/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,Fam,Ima,Otc,Dr,PolID,Pasport,Nac,Obl,Rn,Np,Vneshnost,Prim")] Lico lico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.PolID = new SelectList(db.Pols, "ID", "Txt", lico.PolID);
            return View(lico);
        }

        // GET: Licos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lico lico = await db.Licoes.FindAsync(id);
            if (lico == null)
            {
                return HttpNotFound();
            }
            return View(lico);
        }

        // POST: Licos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Lico lico = await db.Licoes.FindAsync(id);
            db.Licoes.Remove(lico);
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
