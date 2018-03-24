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

namespace AISLTP.Controllers.Journals_registrations
{
    public class AddressesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Addresses
        public async Task<ActionResult> Index()
        {
            var licos = db.Licos.Include( l => l.Nac ).Include( l => l.Np ).
                Include( l => l.Obl ).Include( l => l.Pol ).Include( l => l.Rn ).Include( l => l.Addresses );
            //var addresses = db.Addresses.Include( a => a.Np ).Include( a => a.Obl ).Include( a => a.Rn );
            return View( await licos.ToListAsync() );
        }

        

        // GET: Addresses/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lico lico = await db.Licos.FindAsync( id );
            if (lico == null)
            {
                return HttpNotFound();
            }
            ViewBag.ID = lico.ID;
            ViewBag.Fam = lico.Fam;
            ViewBag.Ima = lico.Ima;
            ViewBag.Otc = lico.Otc;
            return View( lico );
        }

        // POST: Addresses/Edit/5
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "ID,OblID,RnID,NpID,Ul,Dom,Korpus,Kvartira")] Address address)
        {
            if (ModelState.IsValid)
            {
                db.Entry(address).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.NpID = new SelectList(db.Nps, "ID", "Txt", address.NpID);
            ViewBag.OblID = new SelectList(db.Obls, "ID", "Txt", address.OblID);
            ViewBag.RnID = new SelectList(db.Rns, "ID", "Txt", address.RnID);
            return View(address);
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
