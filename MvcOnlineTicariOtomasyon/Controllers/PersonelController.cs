using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class PersonelController : Controller
    {
        // GET: Personel
        Context c = new Context();
        public ActionResult Index()
        { 
            var deger = c.Personels.ToList();
           // var dgr1 = c.Personels.Where(x => x.DepartmanID == id ).Select(y => y.Departman.DepartmanAd).FirstOrDefault();
            //ViewBag.dgr = dgr1;
            return View(deger);
        }
        public ActionResult PersonelGetir(int id)
        {
          
            var dgr = c.Personels.Find(id);
            var dg = c.Personels.Where(x => x.DepartmanID == id).Select(y => y.Departman.DepartmanAd).FirstOrDefault();
            ViewBag.dr = dg;
            return View("PersonelGetir", dgr);
        }
        [HttpGet]
        public ActionResult PersonelEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult PersonelEkle(Personel p)
        {
            c.Personels.Add(p);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelGuncelle(Personel p)
        {
            var dgr = c.Personels.Find(p.PersonelID);
            dgr.PersonelAd = p.PersonelAd;
            dgr.PersonelSoyad = p.PersonelSoyad;
            dgr.PersonelGorsel = p.PersonelGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult PersonelSil(int id)
        {
            var dgr = c.Personels.Find(id);
            c.Personels.Remove(dgr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}