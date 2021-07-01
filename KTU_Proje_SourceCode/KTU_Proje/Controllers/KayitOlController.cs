using KTU_Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KTU_Proje.Controllers
{
    public class KayitOlController : Controller
    {
        // GET: KayitOl
        StudentIDEntities db = new StudentIDEntities();
        [HttpGet]
        public ActionResult Kayit()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Kayit(TBL_STUDENT p)
        {
            if (!ModelState.IsValid)
            {
                return View("Kayit");
            }
            db.TBL_STUDENT.Add(p);
            db.SaveChanges();
            return View();
        }
    }
}