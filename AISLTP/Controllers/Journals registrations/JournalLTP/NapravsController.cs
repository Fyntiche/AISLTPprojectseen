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
    public class NapravsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public async Task<ActionResult> Index()
        {
            var licos = db.Licos.Include(l => l.Nac).Include(l => l.Np).Include(l => l.Obl).Include(l => l.Pol).Include(l => l.Rn);
            return View(await licos.ToListAsync());
            //var medics = db.Medics.Include(m => m.Medcom);
            //return View(await medics.ToListAsync());
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
        public async Task<ActionResult> Show([Bind(Include = "ID,OsnnapID,DataPom,FamD,ImaD,OtcD,TelD,FamO,ImaO,OtcO,TelO")] Lico lico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            return View(lico);
        }

        public ActionResult CreateNaprav()
        {
            ViewBag.OsnnapID = new SelectList(db.Osnnaps, "ID", "Txt");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateNaprav([Bind(Include = "ID,OsnnapID,DataPom,FamD,ImaD,OtcD,TelD,FamO,ImaO,OtcO,TelO")] Naprav CreateNaprav)
        {
            if (ModelState.IsValid)
            {
                db.Licos.Find(Session["IDLico"]).Napravs.Add(CreateNaprav);

                //db.Addresses.Add(CreateAddress);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.OsnnapID = new SelectList(db.Osnnaps, "ID", "Txt", CreateNaprav.OsnnapID);
            return View(CreateNaprav);
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
