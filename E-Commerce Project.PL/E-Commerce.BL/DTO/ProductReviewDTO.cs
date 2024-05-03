using E_Commerce.DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.DTO
{
    public class ProductReviewDTO
    {
        public int ReviewId { get; set; }
        public int Rating { get; set; }
        public string Comment { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string UserName { get; set; }

        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }
        public virtual Product Product { get; set; }
        public virtual User User { get; set; }
    }
}
