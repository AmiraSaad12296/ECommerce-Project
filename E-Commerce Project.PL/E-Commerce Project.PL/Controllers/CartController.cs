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
                        Id=cart.ProductId,
                        Name = cart.Product.ProdName,
                        Description = cart.Product.ShortDesc,
                        Price = cart.Product.Price,
                        ProductURL = Url.Action("GetFile", "product", new { name = cart.Product.ProductImages }),
                        Color = cart.Product.Color,
                        Size = cart.Product.Size,
                        CompanyName = cart.Product.CompanyName,
                        Quantity = cart.Quantity,
                        ProductId = cart.ProductId
                        

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
                UserId = cart.UserId,
                Id = cart.ProductId,
                Name = cart.Product.ProdName,
                Description = cart.Product.ShortDesc,
                Price = cart.Product.Price,
                ProductURL = Url.Action("GetFile", "product", new { name = cart.Product.ProdId }),
                Color = cart.Product.Color,
                Size = cart.Product.Size,
                CompanyName = cart.Product.CompanyName,
                Quantity = cart.Quantity,
                ProductId=cart.ProductId
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
                      return Ok("Product already exist");
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


        [HttpPut("Decrease/{productId}/{userId}")]
        public IActionResult DecreaseCartItemQuantity(int productId, int userId)
        {
         
                var cartItem = unit.CartsRepo.GetCartItem(productId, userId);

                if (cartItem == null)
                {
                    return NotFound("Cart item not found");
                }

                // Decrease the quantity by one
                if (cartItem.Quantity > 1)
                {
                    cartItem.Quantity--;
                }
                else
                {
                    unit.CartsRepo.delete(cartItem.CartId);
                }

                unit.CartsRepo.update(cartItem);

                
                unit.savechanges();

                return Ok();
            }


        [HttpPut("increase/{productId}/{userId}")]
        public IActionResult IncreaseCartItemQuantity(int productId, int userId)
        {
            
                var cartItem = unit.CartsRepo.GetCartItem(productId, userId);

                if (cartItem == null)
                {
                    return NotFound("Cart item not found");
                }

                cartItem.Quantity++;

                unit.CartsRepo.update(cartItem);

                // Save the changes to the database
                unit.savechanges();

                return Ok();
            }
           
        

        [HttpDelete("{userId}")]
        public IActionResult deleteCart(int userId)
        {
            var cartItems = unit.CartsRepo.GetCartItemsByUserId(userId);
            if (cartItems == null || !cartItems.Any())
            {
                return NotFound("Cart items not found for the user.");
            }

            foreach (var cartItem in cartItems)
            {
                unit.CartsRepo.delete(cartItem.CartId); 
            }

            unit.savechanges();

            return Ok();
        }

        [HttpDelete("{productId}/{userId}")]

        public IActionResult DeletefromCart(int productId, int userId)
        {
            var cartItems = unit.CartsRepo.GetCartItem(productId,userId);
            if (cartItems == null)
            {
                return NotFound("Cart item not found");
            }

           else 
            {
                unit.CartsRepo.delete(cartItems.CartId);
            }

            unit.savechanges();

            return Ok();
        }
    }
    }

