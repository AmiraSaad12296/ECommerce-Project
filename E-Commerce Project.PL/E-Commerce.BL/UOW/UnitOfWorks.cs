using E_Commerce.BL.Repository;
using E_Commerce.DAL.Models;

namespace E_Commerce.BL.UOW
{
    public class UnitOfWorks
    {
        EcommerceProjectContext db;
        GenericRepo<Product> productsRepository;
        GenericRepo<Cart> cartsRepo;
        GenericRepo<WishList> wishListRepository;
        GenericRepo<User> usersRepository;
        GenericRepo<Contact> contactsRepository;
        GenericRepo<Category> catagoriesRepository;
        GenericRepo<SubCategory> subcatagoriesRepository;
        GenericRepo<Order> ordersRepository;
        GenericRepo<Payment> paymentsRepository;


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
      

        public GenericRepo<User> UsersRepository
        {
            get
            {
                if (usersRepository == null)
                {
                    usersRepository = new GenericRepo<User>(db);

                }
                return usersRepository;
            }
        }

        public GenericRepo<Contact> ContactRepository
        {
            get
            {
                if (contactsRepository == null)
                {
                    contactsRepository = new GenericRepo<Contact>(db);

                }
                return contactsRepository;
            }
        }

        public GenericRepo<Category> CatagoryRepository
        {
            get
            {
                if (catagoriesRepository == null)
                {
                    catagoriesRepository = new GenericRepo<Category>(db);

                }
                return catagoriesRepository;
            }
        }


        public GenericRepo<SubCategory> SubCatagoryRepository
        {
            get
            {
                if (subcatagoriesRepository == null)
                {
                    subcatagoriesRepository = new GenericRepo<SubCategory>(db);

                }
                return subcatagoriesRepository;
            }
        }

        public GenericRepo<Order> OrdersRepository
        {
            get
            {
                if (ordersRepository == null)
                {
                    ordersRepository = new GenericRepo<Order>(db);

                }
                return ordersRepository;
            }
        }
        public GenericRepo<Payment> PaymentsRepository
        {
            get
            {
                if (paymentsRepository == null)
                {
                    paymentsRepository = new GenericRepo<Payment>(db);

                }
                return paymentsRepository;
            }
        }

        public void savechanges()
        {
            db.SaveChanges();
        }
    }
}

