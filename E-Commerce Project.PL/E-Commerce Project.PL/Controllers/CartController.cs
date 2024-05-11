using E_Commerce.BL.DTO;
using E_Commerce.BL.Repository;
using E_Commerce.BL.UOW;
using E_Commerce.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
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
            this.unit = unit;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            List<Cart> carts = unit.CartsRepo.selectall();
            List<CartProductDTO> cartDTOs = new List<CartProductDTO>();
            if (carts == null) return BadRequest();
            else
            {
                foreach (Cart cart in carts)
                {
                    CartProductDTO cartDTO = new CartProductDTO()
                    {
                        Name = cart.Product.ProdName,
                        Description = cart.Product.ShortDesc,
                        Price = cart.Product.Price,
                        ProductURL = Url.Action("GetFile", "product", new { name = cart.Product.ProductImages }),
                        Color = cart.Product.Color,
                        Size = cart.Product.Size,
                        CompanyName = cart.Product.CompanyName,
                        Quantity = cart.Quantity,

                    };

                    cartDTOs.Add(cartDTO);

                }
                return Ok(cartDTOs);
            }
        }
        [HttpGet("{userId}")]
        public IActionResult getById(int userId)
        {
            var cartItems = unit.CartsRepo.GetCartItemsByUserId(userId);

            if (cartItems == null || !cartItems.Any())
            {
                return NotFound();
            }

            var cartDTOs = cartItems.Select(cart => new CartProductDTO
            {
                Name = cart.Product.ProdName,
                Description = cart.Product.ShortDesc,
                Price = cart.Product.Price,
                ProductURL = Url.Action("GetFile", "product", new { name = cart.Product.ProdId }),
                Color = cart.Product.Color,
                Size = cart.Product.Size,
                CompanyName = cart.Product.CompanyName,
                Quantity = cart.Quantity,
            }).ToList();


            return Ok(cartDTOs);
            }
        


        [HttpPost("add-to-cart/{productId}/{userId}")]
        public IActionResult AddToCart(int productId , int userId)
        {
            var product = unit.ProductsRepository.selectbyid(productId);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

                // Check if the product is already in the cart
                var cartItem = unit.CartsRepo.GetCartItem(productId , userId);
                if (cartItem != null)
                {
                    // If the product is already in the cart, increment the quantity
                    cartItem.Quantity++;
                    unit.CartsRepo.update(cartItem);
                unit.savechanges();
                      return Ok();
                  }
                else
                {
                    // If the product is not in the cart, add it with quantity 1
                    var newCartItem = new Cart
                    {
                        UserId = userId,
                        ProductId = productId,
                        Quantity = 1,
                        CreatedDate = DateTime.Now

                    };
                    unit.CartsRepo.add(newCartItem);


                    // Save changes to the database
                    unit.savechanges();

                    return Created();
                }
               
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
