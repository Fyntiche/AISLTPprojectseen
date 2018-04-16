﻿using System;
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
    public class MedicsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Medics
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
        public async Task<ActionResult> Show([Bind(Include = "ID,MedcomId,Date,Result,Fam,Ima,Otch")] Lico lico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }


            return View(lico);
        }

        public ActionResult CreateMedic()
        {
            ViewBag.MedcomId = new SelectList(db.Medcoms, "ID", "Txt");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> CreateMedic([Bind(Include = "ID,MedcomId,Date,Result,Fam,Ima,Otch")] Medic CreateMedic)
        {

            if (ModelState.IsValid)
            {

                db.Licos.Find(Session["IDLico"]).Medics.Add(CreateMedic);

                //db.Addresses.Add(CreateAddress);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.MedcomId = new SelectList(db.Medcoms, "ID", "Txt", CreateMedic.MedcomId);
            return View(CreateMedic);
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
