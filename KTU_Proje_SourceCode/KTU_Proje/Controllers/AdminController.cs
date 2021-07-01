using KTU_Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KTU_Proje.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        StudentIDEntities db = new StudentIDEntities();

        public ActionResult Index()
        {
            var degerler = db.TBL_STUDENT.ToList();
            return View(degerler);
        }
    }
}