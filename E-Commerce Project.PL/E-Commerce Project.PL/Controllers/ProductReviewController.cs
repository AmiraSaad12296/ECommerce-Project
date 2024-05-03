using E_Commerce.BL.DTO;
using E_Commerce.BL.UOW;
using E_Commerce.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Project.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductReviewController : ControllerBase
    {
        private readonly UnitOfWorks unit;

        public ProductReviewController(UnitOfWorks unit)
        {
            this.unit = unit;
        }
        [HttpGet]
        public IActionResult getAll()
        {
            List<ProductReview> productReviews = unit.ProductReviewRepository.selectall();
            List<ProductReviewDTO> productReviewDTOs = new List<ProductReviewDTO>();
            if (productReviews == null) return NotFound();
            else
            {
                foreach(ProductReview productReview in productReviews)
                {
                    ProductReviewDTO productReviewDTO = new ProductReviewDTO()
                    {
                        ReviewId= productReview.ReviewId,
                        Rating = productReview.Rating,
                        Comment=productReview.Comment,
                        ProductId= productReview.ProductId,
                        UserId=productReview.UserId,
                        ProductName=productReview.Product.ProdName,
                        UserName=productReview.User.UserName,
                        CreatedDate=productReview.CreatedDate


                    };
                    productReviewDTOs.Add(productReviewDTO);
                }
                return Ok();
               
            }
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            ProductReview productReview = unit.ProductReviewRepository.selectbyid(id);
            if (productReview == null)return NotFound();
         
            else
            {
                ProductReviewDTO productReviewDTO = new ProductReviewDTO()
                {
                    ReviewId = productReview.ReviewId,
                    Rating = productReview.Rating,
                    Comment = productReview.Comment,
                    ProductId = productReview.ProductId,
                    UserId = productReview.UserId,
                    ProductName = productReview.Product.ProdName,
                    UserName = productReview.User.UserName,
                    CreatedDate = productReview.CreatedDate
                };
                return Ok(productReviewDTO);
            }

        }
        [HttpPost]
        public IActionResult addProductReview(ProductReview productReview)
        {
            if(ModelState.IsValid)
            {
                unit.ProductReviewRepository.add(productReview);
                unit.savechanges();
                return Ok(productReview);
            }
            return BadRequest();
        }
        [HttpPut]
        public IActionResult update(ProductReview productReview)
        {
            unit.ProductReviewRepository.update(productReview);
            unit.savechanges();
            return Ok(productReview);

        }
        [HttpDelete]
        public IActionResult deleteProductReview(int id)
        {
            unit.ProductReviewRepository.delete(id);
            unit.savechanges();
            return Content("item is Deleted");
        }
    }
}
