using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.DTO
{
    public class CartProductDTO
    {
        public int UserId { get; set; }
        public int  Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
        public string Size { get; set; }
        public string ProductURL { get; set; }
        public string CompanyName { get; set; }
        public decimal Price { get; set; }
        public int? Quantity { get; set; }
        public int ProductId { get; set; }

    

    }
}
