using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.BL.DTO
{
    public class PaymentDTO
    {
        public int paymentId { get; set; }
        public string name { get; set; }
        public int? cardNo { get; set; }
        public string expDate { get; set; }
        public string PaymentMode { get; set; }

    }
}
