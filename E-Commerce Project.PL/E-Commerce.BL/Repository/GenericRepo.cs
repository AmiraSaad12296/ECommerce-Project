using E_Commerce.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Repository
{
    public class GenericRepo<TEntity> where TEntity : class
    {
        EcommerceProjectContext db;

        public GenericRepo(EcommerceProjectContext db)
        {
            this.db = db;
        }

        public List<TEntity> selectall()
        {
            return db.Set<TEntity>().ToList();
        }

        public TEntity selectbyid(int id)
        {
            return db.Set<TEntity>().Find(id);
        }

        public void add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);

        }

        public void update(TEntity entity)
        {
            db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public void delete(int id)
        {
            TEntity obj = db.Set<TEntity>().Find(id);
            db.Set<TEntity>().Remove(obj);
        }

        public User FindName(string username)
        {
            return db.Users.FirstOrDefault(u => u.UserName == username);
        }

       
    }
}
