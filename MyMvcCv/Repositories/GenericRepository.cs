using MyMvcCv.Models.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace MyMvcCv.Repositories
{
    public class GenericRepository<T> where T : class, new()
    {
        DbCvEntities db = new DbCvEntities();

        public List<T> List()
        {
            return db.Set<T>().ToList();
        }

        public void TAdd(T p)
        {
            db.Set<T>().Add(p);
            db.SaveChanges();
        }

        public void TDelete(T p)
        {
            db.Set<T>().Remove(p);
            db.SaveChanges();
        }

        public T TGet(int id) //"int" - olduğu için ve "T" türünde olduğu için geriye bir "return" ifadesi olması gerekiyor!
        {
            return db.Set<T>().Find(id);  //id - ye göre bul
        }

        public void TUpdate(T p)
        {
            db.SaveChanges(); //"TUpdate" Değerini direk olarak değişikleri kayd et... 
        }

        public T Find(Expression<Func<T, bool>> where)
        {
            return db.Set<T>().FirstOrDefault(where);
        }
    }
}