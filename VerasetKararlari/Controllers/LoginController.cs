using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using VerasetKararlari.Models.Entity;

namespace VerasetKararlari.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        private VerasetEntities db = new VerasetEntities();

        public ActionResult GirisYap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GirisYap(Tbl_Kullanicilar p)
        {
            var bilgiler =
                db.Tbl_Kullanicilar.FirstOrDefault(x => x.SICIL == p.SICIL && x.SIFRE == p.SIFRE);
            if (bilgiler != null)
            {
                FormsAuthentication.SetAuthCookie(bilgiler.SICIL, false);
                Session["SICIL"] = bilgiler.SICIL.ToString();

                return RedirectToAction("Index", "Mahkeme");
            }
            else
            {
                return View();
            }



        }
        public ActionResult CikisYap()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("GirisYap", "Login");
        }
    }
}