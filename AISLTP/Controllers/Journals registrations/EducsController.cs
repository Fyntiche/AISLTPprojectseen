﻿using AISLTP.Context;
using AISLTP.Entities;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace AISLTP.Controllers.Journals_registrations
{
    public class EducsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Educs
        public async Task<ActionResult> Index()
        {
            var licos = db.Licos.Include(l => l.Nac).Include(l => l.Np).
                Include(l => l.Obl).Include(l => l.Pol).Include(l => l.Rn).Include(l => l.Addresses);
            return View(await licos.ToListAsync());
        }

        // GET: Educs/Details/5
        public ActionResult Details(int id = 0)
        {
            Lico lico = db.Licos.Find(id);
            if (lico == null)
            {
                return HttpNotFound();
            }
            return View(lico);
        }

        public ActionResult Edit(int id = 0)
        {
            Lico lico = db.Licos.Find(id);
            if (lico == null)
            {
                return HttpNotFound();
            }
            ViewBag.Educs = db.Educs.ToList();
            return View(lico);
        }

        [HttpPost]
        public ActionResult Edit(Lico lico, int[] selectedEducs)
        {
            Lico newLico = db.Licos.Find(lico.ID);
            newLico.Fam = lico.Fam;
            newLico.Ima = lico.Ima;
            newLico.Otc = lico.Otc;

            newLico.Educs.Clear();
            if (selectedEducs != null)
            {
                //получаем выбранные курсы
                foreach (var c in db.Educs.Where(co => selectedEducs.Contains(co.ID)))
                {
                    newLico.Educs.Add(c);
                }
            }

            db.Entry(newLico).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details", new { Id = newLico.ID });
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