using MyMvcCv.Models.Entity;
using MyMvcCv.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvcCv.Controllers
{
    public class YetenekController : Controller
    {
        GenericRepository<TblYetenekler> repo = new GenericRepository<TblYetenekler>();

        public ActionResult Index()
        {
            var yetenekler = repo.List();
            return View(yetenekler);
        }

        [HttpGet]
        public ActionResult YeniYetenek()
        {
            return View();
        }

        [HttpPost]
        public ActionResult YeniYetenek(TblYetenekler p)
        {
           repo.TAdd(p);
            return RedirectToAction("Index");
        }

        public ActionResult YetenekSil(int id) //Silme işlemi için önce silmek istediğimiz şeyi id'si ile bulmamız gerek o yüzden "Find()" methodu nu kullanacağız
        {
            //Önce Bul silemk istediğim şeyi
            var yetenek = repo.Find(x => x.ID == id);
            repo.TDelete(yetenek); //Bulduktan sonra listeden Kaldır 
            return RedirectToAction("Index");  //"Index" - e yönlendir.
        }

        [HttpGet]
        public ActionResult YetenekDuzenle(int id)
        {
            var yetenek = repo.Find(x => x.ID == id);
            return View(yetenek);
           
        }

        [HttpPost]
        public ActionResult YetenekDuzenle(TblYetenekler t)
        {
            var y = repo.Find(x => x.ID == t.ID);
            y.Yetenek = t.Yetenek;
            y.Oran = t.Oran;
            repo.TUpdate(y);
            return RedirectToAction("Index");
        }
    }
}