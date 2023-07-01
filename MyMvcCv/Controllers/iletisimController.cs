using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyMvcCv.Models.Entity;
using MyMvcCv.Repositories;

namespace MyMvcCv.Controllers
{
    public class iletisimController : Controller
    {
       GenericRepository<Tbliletisim> repo = new GenericRepository<Tbliletisim>();

        public ActionResult Index()
        {
            var mesajlar = repo.List();
            return View(mesajlar);
        }

        public ActionResult iletisimSil(int id)
        {
            Tbliletisim t = repo.Find(x => x.ID == id);
            repo.TDelete(t);
            return RedirectToAction("Index");
        }
    }
}