﻿namespace E_Commerce.BL.DTO
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
