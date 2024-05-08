using E_Commerce.DAL.Models;

namespace E_Commerce.BL.DTO
{
    public class OrderDTO
    {
        public int orderId { get; set; }
        public int? quantity { get; set; }
        public string status { get; set; }
        public DateTime orderDate { get; set; }
        public int PaymentId { get; set; }
        public int UserId { get; set; }
        public string ProductName { get; set; }
        public bool IsCancel { get; set; }

    }
}
