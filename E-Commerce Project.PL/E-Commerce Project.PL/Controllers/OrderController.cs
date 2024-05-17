using E_Commerce.BL.DTO;
using E_Commerce.BL.UOW;
using E_Commerce.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
namespace E_Commerce_Project.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        UnitOfWorks unit;
        public OrderController(UnitOfWorks unit)
        {
            this.unit = unit;
        }


      
        [HttpPost]
        [Consumes("application/json")]
        public IActionResult add([FromBody] OrderDTO order)
        {
            if (ModelState.IsValid)
            {
                Order ord = new Order()
                {
                    UserId = order.UserId,
                    PaymentId = order.PaymentId,
                    ProductId = order.ProductId, // Updated to use ProductId from OrderDTO
                    Quantity = order.quantity, // Updated to use lowercase quantity from OrderDTO
                    IsCancel = false,
                    OrderDate = order.orderDate, // Updated to use orderDate from OrderDTO
                    Status = "Pending"
                };

                unit.OrdersRepository.add(ord);
                unit.savechanges();

                return Created("the order is created", ord);
            }

            return BadRequest(ModelState);
        }


    }
}
