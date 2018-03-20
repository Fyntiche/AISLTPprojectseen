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
        
        // GET: Licos/Create
        public ActionResult Index()
        {
            ViewBag.PolID = new SelectList(db.Pols, "ID", "Txt");
            return View();
        }

        // POST: Licos/Create
        // Чтобы защититься от атак чрезмерной передачи данных, включите определенные свойства, для которых следует установить привязку. Дополнительные 
        // сведения см. в статье https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Index([Bind(Include = "ID,Fam,Ima,Otc,Dr,PolID,Pasport,Nac,Obl,Rn,Np,Vneshnost,Prim")] Lico lico)
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
