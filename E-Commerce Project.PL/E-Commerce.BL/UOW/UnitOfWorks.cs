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

        public void savechanges()
        {
            db.SaveChanges();
        }
    }
}

