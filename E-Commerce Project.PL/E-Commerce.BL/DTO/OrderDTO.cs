using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.DTO
{
    public class OrderDTO
    {
        public int orderId { get; set; }
        public string status { get; set; }
        public int? quantity { get; set; }
        public DateTime orderDate { get; set; }


    }
}
