using E_Commerce.BL.DTO;
using E_Commerce.BL.Repository;
using E_Commerce.BL.UOW;
using E_Commerce.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace E_Commerce_Project.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : ControllerBase
    {
        private readonly UnitOfWorks unit;

        public CartController(UnitOfWorks unit)
        {
            this.unit = unit ;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            List<Cart> carts = unit.CartsRepo.selectall();
            List<CartDTO> cartDTOs = new List<CartDTO>();
            if (carts == null) return BadRequest();
            else
            {
                foreach(Cart cart in carts)
                {
                    CartDTO cartDTO = new CartDTO()
                    {
                        CartId = cart.CartId,
                        ProductName = cart.Product.ProdName,
                        Quantity = cart.Quantity,
                        UserName = cart.User.UserName,
                        CreatedDate = cart.CreatedDate,
                    };

                    cartDTOs.Add(cartDTO);
                     
                }
                return Ok(cartDTOs);
            }
        }
        [HttpGet]
        public IActionResult getById(int id)
        {
            Cart cart = unit.CartsRepo.selectbyid(id);
             
            if (cart == null) return NotFound();
            else
            {
                CartDTO cartDTO = new CartDTO()
                {
                    CartId = cart.CartId,
                    ProductName = cart.Product.ProdName,
                    Quantity = cart.Quantity,
                    UserName = cart.User.UserName,
                    CreatedDate = cart.CreatedDate,
                };
                
                return Ok(cartDTO);
            }
        }
        //public async Task<IActionResult> getCartByUserId(int id)
        //{
        //    Cart cart = await unit.CartsRepo.GetCart(id);
        //    CartDTO cartDTO;
        //    if (cart == null) return NotFound();
        //    else
        //    {
        //        cartDTO = new CartDTO();
        //        cartDTO.CartId = cart.CartId;
        //        cartDTO.ProductName = cart.Product.ProdName;
        //        cartDTO.Quantity = cart.Quantity;
        //        cartDTO.UserName = cart.User.UserName;
        //        cartDTO.CreatedDate = cart.CreatedDate;
        //        cartRepo.save();
        //        return Ok(cartDTO);
        //    }
        //}
        [HttpPost]
        public IActionResult addCart(Cart cart)
        {
            if (ModelState.IsValid)
            {
                unit.CartsRepo.add(cart);
                unit.savechanges();
                return Ok(cart);

            }
            return BadRequest();
        }

        [HttpPut]
        public IActionResult updateCart(Cart cart)
        {
            unit.CartsRepo.update(cart);
            unit.savechanges();
            return Ok(cart);
        }
        [HttpDelete]
        public IActionResult deleteCart(int id)
        {
            
            unit.CartsRepo.delete(id);
            unit.savechanges();
            return Content("item is Deleted");
        }
    }
}
