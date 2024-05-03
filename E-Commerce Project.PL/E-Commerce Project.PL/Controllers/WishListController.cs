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
                        ProductName = wish.Product.ProdName,
                        UserName = wish.User.UserName
                    };
                    wishListDTOs.Add(wishListDTO);
                }
                return Ok(wishListDTOs);
            }

        }
        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            WishList wishlist = unit.WishListRepository.selectbyid(id);
            if (wishlist == null) return NotFound();
            else
            {
                WishListDTO wishList = new WishListDTO()
                {
                    WishLstId = wishlist.WishLstId,
                    ProductId = wishlist.ProductId,
                    UserId = wishlist.UserId,
                    CreatedDate = wishlist.CreatedDate,
                    ProductName = wishlist.Product.ProdName,
                    UserName = wishlist.User.UserName

                };
                return Ok(wishList);
            }
        }
        [HttpPost]
        public IActionResult addWishList(WishList wish)
        {
            if (ModelState.IsValid)
            {
                unit.WishListRepository.add(wish);
                unit.savechanges();
                return Ok(wish);

            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult updateWishList(WishList wish)
        {
            unit.WishListRepository.update(wish);
            unit.savechanges();
            return Ok(wish);

        }
        [HttpDelete]
        public IActionResult deleteWishList(int id)
        {
            unit.WishListRepository.delete(id);
            unit.savechanges();
            return Content("item is Deleted");

        }
    }
}
