﻿using AISLTP.Context;
using AISLTP.Entities;
using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace AISLTP.Controllers.Sp
{
    public class EducController : Controller
    {
        // GET: Educ
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetEduc(string sidx, string sort, int page, int rows, bool _search, string searchField, string searchOper, string searchString)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            sort = sort ?? "";
            int pageIndex = Convert.ToInt32(page) - 1;
            int pageSize = rows;

            var EducList = db.Educs.Select(
                    t => new
                    {
                        t.ID,
                        t.Txt,
                    });
            if (_search)
            {
                switch (searchField)
                {
                    case "Txt":
                        EducList = EducList.Where(t => t.Txt.Contains(searchString));
                        break;
                }
            }
            int totalRecords = EducList.Count();
            var totalPages = (int)Math.Ceiling((float)totalRecords / (float)rows);
            if (sort.ToUpper() == "DESC")
            {
                EducList = EducList.OrderByDescending(t => t.Txt);
                EducList = EducList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            else
            {
                EducList = EducList.OrderBy(t => t.Txt);
                EducList = EducList.Skip(pageIndex * pageSize).Take(pageSize);
            }
            var jsonData = new
            {
                total = totalPages,
                page,
                records = totalRecords,
                rows = EducList
            };
            return Json(jsonData, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public string Create([Bind(Exclude = "Id")] Educ Model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Educs.Add(Model);

                    db.SaveChanges();
                    msg = "Сохранено успешно";
                }
                else
                {
                    msg = "Данные не прошли проверку ввода";
                }
            }
            catch (Exception ex)
            {
                msg = "Произошла ошибка:" + ex.Message;
            }
            return msg;
        }

        public string Edit(Educ Model)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            string msg;
            try
            {
                if (ModelState.IsValid)
                {
                    db.Entry(Model).State = EntityState.Modified;
                    db.SaveChanges();
                    msg = "Сохранено успешно";
                }
                else
                {
                    msg = "Данные не прошли проверку ввода";
                }
            }
            catch (Exception ex)
            {
                msg = "Произошла ошибка:" + ex.Message;
            }
            return msg;
        }

        public string Delete(int Id)
        {
            ApplicationDbContext db = new ApplicationDbContext();
            Educ Educs = db.Educs.Find(Id);
            db.Educs.Remove(Educs);
            db.SaveChanges();
            return "Удалено успешно";
        }
    }
}