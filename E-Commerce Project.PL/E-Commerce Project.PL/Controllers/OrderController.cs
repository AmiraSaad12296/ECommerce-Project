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


        //[HttpGet]   //for admin
        //[Authorize(Roles ="Admin")]
        //public IActionResult getAll()
        //{
        //    List<Order> orders = unit.OrdersRepository.selectall();
        //    if(orders != null && orders.Count > 0)
        //    {
        //        List<OrderDTO> dtos = new List<OrderDTO>();
        //        foreach (Order order in orders)
        //        {
        //            OrderDTO dto = new OrderDTO()
        //            {
        //                orderId = order.OrderId,
        //                quantity = order.Quantity,
        //                status = order.Status,
        //                orderDate = order.OrderDate,
        //                PaymentId = order.PaymentId,
        //                ProductName = unit.ProductsRepository.selectbyid(order.ProductId).ProdName,
        //                UserId = order.UserId,
        //                IsCancel = order.IsCancel,
        //            };
        //            dtos.Add(dto);
        //        }
        //        return Ok(dtos);
        //    }
        //    return NotFound("No orders found.");
        //}

        //[Authorize(Roles ="Customer")]
        //[HttpGet("userOrders/{userId}")] //for specific user
        //public IActionResult getAllOrdersByUserId(int userId)
        //{
        //    User user = unit.UsersRepository.selectbyid(userId);
        //    if(user != null)
        //    {
        //        List<Order> orders = user.Orders.ToList();
        //        if (orders != null && orders.Count>0)
        //        {
        //            List<OrderDTO> dtos = new List<OrderDTO>();
        //            foreach (Order order in orders)
        //            {
        //                OrderDTO dto = new OrderDTO()
        //                {
        //                    orderId = order.OrderId,
        //                    quantity = order.Quantity,
        //                    status = order.Status,
        //                    orderDate = order.OrderDate,
        //                    PaymentId = order.PaymentId,
        //                    ProductName = unit.ProductsRepository.selectbyid(order.ProductId).ProdName,
        //                    UserId = order.UserId,
        //                    IsCancel = order.IsCancel
        //                };
        //                dtos.Add(dto);
        //            }
        //            return Ok(dtos);
        //        }
        //        return NotFound("No orders found.");
        //    }
        //    return BadRequest("user not found.");
        //}

        //[Authorize]
        //[HttpGet("{id}")] //for admin
        //public IActionResult getById(int id)
        //{
        //    Order order = unit.OrdersRepository.selectbyid(id);
        //    if (order != null)
        //    {
        //        OrderDTO dto = new OrderDTO()
        //        {
        //            orderId = order.OrderId,
        //            quantity = order.Quantity,
        //            status = order.Status,
        //            orderDate = order.OrderDate,
        //            PaymentId = order.PaymentId,
        //            ProductName = unit.ProductsRepository.selectbyid(order.ProductId).ProdName,
        //            UserId = order.UserId,
        //            IsCancel = order.IsCancel
        //        };
        //        return Ok(dto);
        //    }
        //    return NotFound("order does not exist");
        //}

        //[Authorize(Roles = "Customer")]
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

    //    [Authorize(Roles = "Customer")]
    //    [HttpPut]
    //    [Consumes("application/json")]
    //    public IActionResult update(Order order)
    //    {
    //        if (ModelState.IsValid)
    //        {
    //            unit.OrdersRepository.update(order);
    //            unit.savechanges();
    //            return Ok(order);
    //        }
    //        return BadRequest(ModelState);
            
    //    }

    //    [Authorize]
    //    [HttpDelete]
    //    public IActionResult delete(int id)
    //    {
    //        unit.OrdersRepository.delete(id);
    //        unit.savechanges();
    //        return Ok();
    //    }

    }
}
