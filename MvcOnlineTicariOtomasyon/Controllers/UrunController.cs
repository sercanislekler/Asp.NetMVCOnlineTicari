using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineTicariOtomasyon.Models.Sınıflar;

namespace MvcOnlineTicariOtomasyon.Controllers
{
    public class UrunController : Controller
    {
        // GET: Urun
        Context c = new Context();
        public ActionResult Index()
        {
            var urunler = c.Uruns.ToList();
            return View(urunler);
        }
        [HttpGet]
        public ActionResult YeniUrun()
        {
            List<SelectListItem> deger = (from s in c.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = s.KategoriAd,
                                              Value = s.KategoriID.ToString()
                                          }).ToList();
            ViewBag.dgr = deger;
            return View();
        }
        [HttpPost]
        public ActionResult YeniUrun(Urun u)
        {
            c.Uruns.Add(u);
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunPasif(int id)
        {
            var dgr = c.Uruns.Find(id);
            if (dgr.Durum != false)
            {
                dgr.Durum = false;
            }
            else
            {
                dgr.Durum = true;
            }
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunGetir (int id)
        {
            List<SelectListItem> deger1 = (from s in c.Kategoris.ToList()
                                          select new SelectListItem
                                          {
                                              Text = s.KategoriAd,
                                              Value = s.KategoriID.ToString()
                                          }).ToList();
            ViewBag.dgr = deger1;
            var dgr = c.Uruns.Find(id);
            return View("UrunGetir", dgr);
        }
        public ActionResult UrunGuncelle(Urun p)
        {
            var urn = c.Uruns.Find(p.UrunID);
            urn.AlisFiyat = p.AlisFiyat;
            urn.Durum = p.Durum;
            urn.Kategoriid = p.Kategoriid;
            urn.Marka = p.Marka;
            urn.SatiFiyat = p.SatiFiyat;
            urn.Stok = p.Stok;
            urn.UrunAdi = p.UrunAdi;
            urn.UrunGorsel = p.UrunGorsel;
            c.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult UrunListesi()
        {
            var degerler = c.Uruns.ToList();
            return View(degerler);
        }
    }
}