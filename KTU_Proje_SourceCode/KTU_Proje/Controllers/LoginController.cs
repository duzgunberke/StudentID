using KTU_Proje.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace KTU_Proje.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        StudentIDEntities db = new StudentIDEntities();
        public ActionResult GirisYap()
        {
            return View();
        }
        [HttpPost]
        public ActionResult GirisYap(TBL_STUDENT t)
        {
            var bilgiler = db.TBL_STUDENT.FirstOrDefault(x => x.MAIL == t.MAIL && x.SIFRE == t.MAIL);
            if(bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.MAIL, false);
                Session["Mail"] = bilgiler.MAIL.ToString();
                return RedirectToAction("Index","Panelim");
            }
            else
            {
                return View();
            }
        }
    }
}