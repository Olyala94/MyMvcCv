using MyMvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvcCv.Controllers
{
    public class DefaultController : Controller
    {
        // GET: Default
        DbCvEntities db = new DbCvEntities();       
        public ActionResult Index()
        {
            var degerler = db.TblHakkimda.ToList();
            return View(degerler);
        }

        public PartialViewResult Deneyim()
        {
            var deneyimler = db.TblDeneyimlerim.ToList();
            return PartialView(deneyimler);
        }

        public PartialViewResult Egitimlerim()
        {
            var egitimler = db.TblEgitimlerim.ToList();
            return PartialView(egitimler);
        }

        public PartialViewResult Yeteneklerim()
        {
            var yetenekler = db.TblYetenekler.ToList();
            return PartialView(yetenekler);
        }

        public PartialViewResult Hobilerim()
        {
            var hobiler = db.TblHobilerim.ToList();
            return PartialView(hobiler);
        }

        public PartialViewResult Sertifikalar()
        {
            var sertifika = db.TblSertifikalarim.ToList();
            return PartialView(sertifika);
        }

        [HttpGet]  //Sayfanın Yüklendiği zaman Çlışacak
        public PartialViewResult Iletisim()
        {
            return PartialView();
        }

        //Post olduğu zaman çalışacak(eğer tek metot ile işlemleri yapmaya çalışırsak,bir kere kayd edecek,kayt ettikten sonra sayfayı tekrer boş kayt edecek(yani,hiç bir şey plmadaniki defa kayd etmiş olacak))
        [HttpPost]
        public PartialViewResult Iletisim(Tbliletisim t)
        {
            t.Tarih = DateTime.Parse(DateTime.Now.ToShortDateString());
            db.Tbliletisim.Add(t);
            db.SaveChanges();
            return PartialView();
        }
    }
}