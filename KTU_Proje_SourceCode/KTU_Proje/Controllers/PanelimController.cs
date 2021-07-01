using KTU_Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KTU_Proje.Controllers
{
    public class PanelimController : Controller
    {
        StudentIDEntities db = new StudentIDEntities();

        // GET: Panelim
        [HttpGet]

        public ActionResult Index()
        {


            var uyemail = (string)Session["Mail"];
            //var degerler = db.TBL_UYELER.FirstOrDefault(z => z.MAIL == uyemail);
            var degerler = db.TBL_STUDENT.ToList();
            var d1 = db.TBL_STUDENT.Where(x => x.MAIL == uyemail).Select(y => y.AD).FirstOrDefault();
            ViewBag.d1 = d1;
            var d2 = db.TBL_STUDENT.Where(x => x.MAIL == uyemail).Select(y => y.SOYAD).FirstOrDefault();
            ViewBag.d2 = d2;

            var d5 = db.TBL_STUDENT.Where(x => x.MAIL == uyemail).Select(y => y.OKUL).FirstOrDefault();
            ViewBag.d5 = d5;
            var d6 = db.TBL_STUDENT.Where(x => x.MAIL == uyemail).Select(y => y.TELEFON).FirstOrDefault();
            ViewBag.d6 = d6;
            var d7 = db.TBL_STUDENT.Where(x => x.MAIL == uyemail).Select(y => y.MAIL).FirstOrDefault();
            ViewBag.d7 = d7;
            var uyeid = db.TBL_STUDENT.Where(x => x.MAIL == uyemail).Select(y => y.ID).FirstOrDefault();


            return View(degerler);


        }
        [HttpPost]
        public ActionResult Index2(TBL_STUDENT u)
        {


            var kullanici = (string)Session["Mail"];
            var uye = db.TBL_STUDENT.FirstOrDefault(x => x.MAIL == kullanici);
            uye.SIFRE = u.SIFRE;
            uye.AD = u.AD;
            uye.SOYAD = u.SOYAD;
            uye.MAIL = u.MAIL;
            uye.OKUL = u.OKUL;
            uye.OGRENCIBELGESI = u.OGRENCIBELGESI;
            db.SaveChanges();
            return RedirectToAction("Index");


        }

        public PartialViewResult Partial1()
        {
            var kullanici2 = (string)Session["Mail"];
            var id = db.TBL_STUDENT.Where(x => x.MAIL == kullanici2).Select(y => y.ID).FirstOrDefault();
            var uyebul = db.TBL_STUDENT.Find(id);
            return PartialView("Partial1", uyebul);
        }

    }
}