using E_Commerce.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.Repository
{
    public class CartRepo : GenericRepo<Cart>
    {
        private readonly EcommerceProjectContext db;

        public CartRepo(EcommerceProjectContext db) : base(db)
        {
            this.db = db;
        }
      
        public async Task<Cart> GetCart(int userId)
        {
            var cart = await db.Carts.Where(c =>c.UserId==userId).Include(a => a.User)
                .Include(i => i.Product) .FirstOrDefaultAsync();
            return cart;
        }
    


    }
}
