using E_Commerce.BL.Repository;
using E_Commerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.UOW
{
    public class UnitOfWorks
    {
        EcommerceProjectContext db;
        GenericRepo<Product> productsRepository;
        GenericRepo<Cart> cartsRepo;
        GenericRepo<WishList> wishListRepository;
        GenericRepo<ProductReview> productReviewRepository;


        public UnitOfWorks(EcommerceProjectContext db)
        {
            this.db = db;

        }

        public GenericRepo<Product> ProductsRepository
        {
            get
            {
                if (productsRepository == null)
                {
                    productsRepository = new GenericRepo<Product>(db);

                }
                return productsRepository;
            }
        }
        public GenericRepo<WishList> WishListRepository
        {
            get
            {
                if (wishListRepository == null)
                {
                    wishListRepository = new GenericRepo<WishList>(db);

                }
                return wishListRepository;
            }
        }
        public GenericRepo<Cart> CartsRepo
        {
            get
            {
                if (cartsRepo == null)
                {
                    cartsRepo = new GenericRepo<Cart>(db);

                }
                return cartsRepo;
            }
        }
        public GenericRepo<ProductReview> ProductReviewRepository
        {
            get
            {
                if (productReviewRepository == null)
                {
                    productReviewRepository = new GenericRepo<ProductReview>(db);

                }
                return productReviewRepository;
            }
        }

        public void savechanges()
        {
            db.SaveChanges();
        }
    }
}

