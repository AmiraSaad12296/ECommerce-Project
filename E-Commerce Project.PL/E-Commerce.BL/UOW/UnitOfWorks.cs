﻿using E_Commerce.BL.Repository;
using E_Commerce.DAL.Models;
using Microsoft.EntityFrameworkCore;
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
        GenericRepo<User> usersRepository;
        GenericRepo<Contact> contactsRepository;
        GenericRepo<Category> catagoriesRepository;
        GenericRepo<SubCategory> subcatagoriesRepository;





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
        public void savechanges()
        {
            db.SaveChanges();
        }
    }
}

