using E_Commerce.DAL.Models;
using Microsoft.EntityFrameworkCore;

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

        public  void add(TEntity entity)
        {
            db.Set<TEntity>().Add(entity);

        }

        public   void update(TEntity entity)
        {
            db.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }

        public  void delete(int id)
        {
            TEntity obj = db.Set<TEntity>().Find(id);
            db.Set<TEntity>().Remove(obj);
        }

        public User FindName(string username)
        {
            return db.Users.FirstOrDefault(u => u.UserName == username);
        }
        public  Cart GetCartItem( int productId , int userid)
        {
            return  db.Carts.FirstOrDefault(c =>  c.ProductId == productId & c.UserId == userid);
        }

        public List<Cart> GetCartItemsByUserId(int userId)
        {
            return db.Carts.Where(c => c.UserId == userId).ToList();
        }

        public List<Product> GetProductBySubcatId(int SubcatId)
        {
            return db.Products.Where(c => c.SubCatId == SubcatId).ToList();
        }

        public WishList GetwishItem(int productId, int userid)
        {
            return db.WishLists.FirstOrDefault(c => c.ProductId == productId & c.UserId == userid);
        }

        public List<WishList> GetwishItemsByUserId(int userId)
        {
            return db.WishLists.Where(c => c.UserId == userId).ToList();
        }
    }
}
