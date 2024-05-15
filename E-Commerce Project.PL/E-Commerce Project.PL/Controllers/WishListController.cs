using E_Commerce.BL.DTO;
using E_Commerce.BL.UOW;
using E_Commerce.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Project.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WishListController : ControllerBase
    {
        private readonly UnitOfWorks unit;

        public WishListController(UnitOfWorks unit) 
        {
            this.unit = unit;
        }
        [HttpGet]
        public IActionResult getAll() 
        {
            List<WishList> wishlists = unit.WishListRepository.selectall();
            List<WishListDTO> wishListDTOs = new List<WishListDTO>();
            if (wishlists == null) return NotFound();
            else
            {
                foreach(WishList wish in wishlists)
                {
                    WishListDTO wishListDTO = new WishListDTO()
                    {
                        WishLstId = wish.WishLstId,
                        ProductId = wish.ProductId,
                        UserId = wish.UserId,
                        CreatedDate = wish.CreatedDate,
                        
                    };
                    wishListDTOs.Add(wishListDTO);
                }
                return Ok(wishListDTOs);
            }

        }
        [HttpGet("{userId}")]
        public IActionResult getById(int userId)
        {
            var wishItems = unit.WishListRepository.GetwishItemsByUserId(userId);

            if (wishItems == null)
            {
                return NotFound();
            }

            var wishDTOs = wishItems.Select(wish => new WishProductDTO
            {
                UserId=wish.UserId,
                Id =wish.Product.ProdId,
                Name = wish.Product.ProdName,
                Description = wish.Product.ShortDesc,
                Price = wish.Product.Price,
                ProductURL = Url.Action("GetFile", "product", new { name = wish.Product.ProdId }),
                Color = wish.Product.Color,
                Size = wish.Product.Size,
                CompanyName = wish.Product.CompanyName,
             
            }).ToList();


            return Ok(wishDTOs);
        }



        [HttpPost("add-to-wishlist/{productId}/{userId}")]
        public IActionResult AddToWish(int productId, int userId)
        {
            var product = unit.ProductsRepository.selectbyid(productId);
            if (product == null)
            {
                return NotFound("Product not found.");
            }

            // Check if the product is already in the wishlist
            var wishItem = unit.WishListRepository.GetwishItem(productId, userId);
            if (wishItem != null)
            {
                
                return Ok("Product already exist");
            }
            else
            {
                // If the product is not in the cart, add it 
                var newwishItem = new WishList
                {

                    UserId = userId,
                    ProductId = productId,
                    CreatedDate = DateTime.Now

                };
                unit.WishListRepository.add(newwishItem);


                // Save changes to the database
                unit.savechanges();

                return Created();
            }

        }



        [HttpPut]
        public IActionResult updateWishList(WishList wish)
        {
            unit.WishListRepository.update(wish);
            unit.savechanges();
            return Ok(wish);

        }


        [HttpDelete("{userId}")]
        public IActionResult deletewish(int userId)
        {
            var wishItems = unit.WishListRepository.GetwishItemsByUserId(userId);
            if (wishItems == null)
            {
                return NotFound("Wished items not found for the user.");
            }

            foreach (var wishItem in wishItems)
            {
                unit.WishListRepository.delete(wishItem.WishLstId);
            }

            unit.savechanges();

            return Content("Wished items are deleted for the user.");
        }


        [HttpDelete("{productId}/{userId}")]

        public IActionResult DeletefromWish(int productId, int userId)
        {
            var WishItems = unit.WishListRepository.GetwishItem(productId, userId);
            if (WishItems == null)
            {
                return NotFound("item not found");
            }

            else
            {
                unit.WishListRepository.delete(WishItems.WishLstId);
            }

            unit.savechanges();

            return Ok();
        }
    }
}

