using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class CariController : Controller
    {
        // GET: Cari
        Context c = new Context();
        public ActionResult Index()
        {
            var deger = c.Carilers.ToList();
            return View(deger);
        }
        [HttpGet]
        public ActionResult YeniCari()
        {
            return View();
        }
        [HttpPost]
        public ActionResult YeniCari(Cariler p)
        {
            c.Carilers.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariSil(int id)
        {
            var dgr = c.Carilers.Find(id);
            c.Carilers.Remove(dgr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGuncelle(Cariler p)
        {
            var dgr = c.Carilers.Find(p.CariID);
            dgr.CariAd = p.CariAd;
            dgr.CariSoyad = p.CariSoyad;
            dgr.CariSehir = p.CariSehir;
            dgr.CariMail = p.CariMail;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult CariGetir(int id)
        {
            var dgr = c.Carilers.Find(id);
            return View("CariGuncelle", dgr);
        }
        public ActionResult CariDetay(int id)
        {
            var deger = c.Uruns.Where(x => x.UrunID == id).ToList();
            return View(deger);
        }
    }
}