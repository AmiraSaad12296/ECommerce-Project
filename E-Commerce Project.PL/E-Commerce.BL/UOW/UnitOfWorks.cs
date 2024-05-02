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

