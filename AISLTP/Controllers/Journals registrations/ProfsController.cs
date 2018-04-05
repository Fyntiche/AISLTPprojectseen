using AISLTP.Context;
using AISLTP.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AISLTP.Controllers.Journals_registrations
{

    public class ProfsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Prof
        public async Task<ActionResult> Index()
        {
            var licos = db.Licos.Include(l => l.Nac).Include(l => l.Np).
                Include(l => l.Obl).Include(l => l.Pol).Include(l => l.Rn).Include(l => l.Addresses);
            //var addresses = db.Addresses.Include( a => a.Np ).Include( a => a.Obl ).Include( a => a.Rn );
            return View(await licos.ToListAsync());
        }

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
            ViewBag.Profs = db.Profs.ToList();
            return View(lico);
        }

        [HttpPost]
        public ActionResult Edit(Lico lico, int[] selectedProfs)
        {
            Lico newLico = db.Licos.Find(lico.ID);
            newLico.Fam = lico.Fam;
            newLico.Ima = lico.Ima;
            newLico.Otc = lico.Otc;

            newLico.Profs.Clear();
            if (selectedProfs != null)
            {
                //получаем выбранные курсы
                foreach (var c in db.Profs.Where(co => selectedProfs.Contains(co.ID)))
                {
                    newLico.Profs.Add(c);
                }
            }

            db.Entry(newLico).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Details", new { Id = newLico.ID });
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}