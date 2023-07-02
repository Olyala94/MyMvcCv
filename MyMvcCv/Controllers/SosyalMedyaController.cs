using MyMvcCv.Models.Entity;
using MyMvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvcCv.Controllers
{
    public class SosyalMedyaController : Controller
    {
        GenericRepository<TblSosyalMedya> repo = new GenericRepository<TblSosyalMedya>(); 

        public ActionResult Index()
        {
            var veriler = repo.List();
            return View(veriler);
        }

        [HttpGet]
        public ActionResult SosyalMedyaEkle()
        {
            return View();  
        }

        [HttpPost]
        public ActionResult SosyalMedyaEkle(TblSosyalMedya p)
        {
            repo.TAdd(p);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SosyalMedyaSayfaGetir(int id)
        {
            var hesap = repo.Find(x=>x.ID == id);    
            return View(hesap);
        }

        [HttpPost]
        public ActionResult SosyalMedyaSayfaGetir(TblSosyalMedya p)
        {
           var hesap = repo.Find(x=>x.ID == p.ID);
            hesap.Ad = p.Ad;
            hesap.Durum = true;   
            hesap.Link = p.Link; 
            hesap.ikon = p.ikon;
            repo.TUpdate(hesap);
            return RedirectToAction("Index");
        }

        public ActionResult SosyalMedyaSil(int id) //Silme işlemi için önce silmek istediğimiz şeyi id'si ile bulmamız gerek o yüzden "Find()" methodu nu kullanacağız
        {
            //Önce Bul silemk istediğim şeyi
            var hesap = repo.Find(x => x.ID == id);
            hesap.Durum = false;
            repo.TUpdate(hesap); //Bulduktan sonra listeden Kaldır 
            return RedirectToAction("Index"); //"Index" - e yönlendir.
        }
    }
}