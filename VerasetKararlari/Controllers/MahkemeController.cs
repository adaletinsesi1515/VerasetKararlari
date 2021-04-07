using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using VerasetKararlari.Models.Entity;

namespace VerasetKararlari.Controllers
{
    public class MahkemeController : Controller
    {
        // GET: Mahkeme
        private VerasetEntities db = new VerasetEntities();
        [Authorize]
        public ActionResult Index()
        {
            var liste = db.Tbl_Veraset.Where(i => i.DURUM == true).ToList();
            return View(liste);
        }

        [HttpGet]
        public ActionResult Ekle()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Ekle(Tbl_Veraset p)
        {
            db.Tbl_Veraset.Add(p);
            p.DURUM = true;
            p.KAYITTARIHI = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


        public ActionResult Getir(int id)
        {
            var bilgi = db.Tbl_Veraset.Find(id);
            return View("Getir", bilgi);
        }

        public ActionResult Guncelle(Tbl_Veraset p)
        {
            var bilgi = db.Tbl_Veraset.Find(p.ID);
            bilgi.KARARNO= p.KARARNO;
            bilgi.DAVACI= p.DAVACI;
            bilgi.VEFATEDEN= p.VEFATEDEN;
            bilgi.DURUM = true;
            bilgi.KAYITTARIHI = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}