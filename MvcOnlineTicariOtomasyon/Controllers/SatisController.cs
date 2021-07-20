using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class SatisController : Controller
    {
        // GET: Satis
        Context c = new Context();
        public ActionResult Index()
        {
            var degerler = c.SatisHarekets.ToList();
            return View(degerler);
        }
        [HttpGet]
        public ActionResult YeniSatis()
        {
            List<SelectListItem> deger = (from s in c.Uruns.ToList()
                                          select new SelectListItem
                                          {
                                              Text = s.UrunAdi,
                                              Value = s.UrunID.ToString()
                                          }).ToList();

            List<SelectListItem> deger1 = (from s in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = s.CariAd + " " + s.CariSoyad,
                                               Value = s.CariID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from s in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = s.PersonelAd + " " + s.PersonelSoyad,
                                               Value = s.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            ViewBag.dgr1 = deger1;
            ViewBag.dgr = deger;
            return View();
        }
        [HttpPost]
        public ActionResult YeniSatis (SatisHareket s)
        {
            s.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            c.SatisHarekets.Add(s);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult SatisGetir(int id)
        {
            List<SelectListItem> deger = (from s in c.Uruns.ToList()
                                          select new SelectListItem
                                          {
                                              Text = s.UrunAdi,
                                              Value = s.UrunID.ToString()
                                          }).ToList();

            List<SelectListItem> deger1 = (from s in c.Carilers.ToList()
                                           select new SelectListItem
                                           {
                                               Text = s.CariAd + " " + s.CariSoyad,
                                               Value = s.CariID.ToString()
                                           }).ToList();

            List<SelectListItem> deger2 = (from s in c.Personels.ToList()
                                           select new SelectListItem
                                           {
                                               Text = s.PersonelAd + " " + s.PersonelSoyad,
                                               Value = s.PersonelID.ToString()
                                           }).ToList();
            ViewBag.dgr2 = deger2;
            ViewBag.dgr1 = deger1;
            ViewBag.dgr = deger;
            var deger3 = c.SatisHarekets.Find(id);
            return View("SatisGetir", deger3);
        }
        [HttpPost]
        public ActionResult SatisGetir(SatisHareket s)
        {
            var dgr = c.SatisHarekets.Find(s.SatisID);
            dgr.SatisID = s.SatisID;
            dgr.UrunID = s.UrunID;
            dgr.PersonelID = s.PersonelID;
            dgr.Fiyat = s.Fiyat;
            dgr.Adet = s.Adet;
            dgr.Tarih = DateTime.Parse(s.Tarih.ToShortDateString());
            dgr.ToplamTutar = s.ToplamTutar;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult SatisDetay (int id)
        {
            var dgr = c.SatisHarekets.Where(x => x.SatisID == id).ToList();
            return View(dgr);
        }
    }
}