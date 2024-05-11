using E_Commerce.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.DTO
{
    public class CartDTO
    {
        public int CartId { get; set; }
        public int? Quantity { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        public DateTime CreatedDate { get; set; }

    }
}
