using E_Commerce.BL.DTO;
using E_Commerce.BL.UOW;
using E_Commerce.DAL.Models;
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


        [HttpGet]
        public IActionResult getAll()
        {
            List<Order> orders = unit.OrdersRepository.selectall();
            if (orders == null || orders.Count == 0)
            {
                return NotFound("No orders found.");
            }

            List<OrderDTO> dtos = new List<OrderDTO>();

            foreach (Order order in orders)
            {
                OrderDTO dto = new OrderDTO()
                {
                    orderId = order.OrderId,
                    quantity = order.Quantity,
                    status = order.Status,
                    orderDate = order.OrderDate,
                };
                dtos.Add(dto);
            }
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            Order order = unit.OrdersRepository.selectbyid(id);
            if (order == null) return NotFound();

            OrderDTO dto = new OrderDTO()
            {
                orderId = order.OrderId,
                quantity = order.Quantity,
                status = order.Status,
                orderDate = order.OrderDate
            };
            return Ok(dto);
        }


        /* {
              "quantity": 3,
              "status": "pending",
              "orderDate": "2024-05-01T21:50:33.489Z",
              "isCancel": true,
              "paymentId": 1,
              "userId": 1,
              "productId": 1
           } */
        [HttpPost] //modelstate not working
        [Consumes("application/json")]
        public IActionResult add([FromBody] Order order)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                unit.OrdersRepository.add(order);
                unit.savechanges();
                return Created("", order);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while adding.. " + ex);
            }
        }

        /*
         {
          "orderId": 34,
          "quantity": 0,
          "status": "old",
          "orderDate": "2024-05-01T22:05:49.075Z",
          "isCancel": false,
          "paymentId": 1,
          "userId": 1,
          "productId": 1
         }
        */
        [HttpPut]
        [Consumes("application/json")]
        public ActionResult update(Order order)
        {
            unit.OrdersRepository.update(order);
            unit.savechanges();
            return Ok();

        }

        [HttpDelete]
        public ActionResult delete(int id)
        {
            unit.OrdersRepository.delete(id);
            unit.savechanges();
            return Ok();
        }

    }
}
