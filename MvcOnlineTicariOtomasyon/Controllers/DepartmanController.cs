using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class DepartmanController : Controller
    {
        // GET: Departman
        Context c = new Context();
        public ActionResult Index()
        {
            var dgr = c.Departmen.ToList();
            return View(dgr);
        }
        [HttpGet]
        public ActionResult DepartmanEkle()
        {
            return View();
        }
        [HttpPost]
        public ActionResult DepartmanEkle(Departman d)
        { 
                c.Departmen.Add(d);
                c.SaveChanges();  
                return RedirectToAction("Index");
        }
        public ActionResult DepartmanGetir(int id)
        {
            var dpt = c.Departmen.Find(id);
            return View("DepartmanGuncelle", dpt);
        }
        public ActionResult DepartmanGuncelle(Departman d)
        {
            var dgr = c.Departmen.Find(d.DepartmanID);
            dgr.DepartmanAd = d.DepartmanAd;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        
        public ActionResult DepartmanSil(int id)
        {
            var dgr = c.Departmen.Find(id);
            c.Departmen.Remove(dgr);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult DepartmanDetay (int id)
        {
            var deger = c.Personels.Where(x => x.DepartmanID == id).ToList();
            var dpt = c.Departmen.Where(x => x.DepartmanID == id).Select(y => y.DepartmanAd).FirstOrDefault();
            ViewBag.d = dpt;
            return View(deger);
        }
        public ActionResult DepartmanPersonelSatis(int id)
        {
            var deger = c.SatisHarekets.Where(x => x.PersonelID == id).ToList();
            var per = c.Personels.Where(x => x.PersonelID == id).Select(y => y.PersonelAd +" "+ y.PersonelSoyad).FirstOrDefault();
            ViewBag.p = per;
            return View(deger);
        }

    }
}