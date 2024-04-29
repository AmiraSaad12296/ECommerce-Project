using E_Commerce.DAL.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.BL.DTO;

namespace E_Commerce_Project.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        EcommerceProjectContext db=new EcommerceProjectContext();

        public productController(EcommerceProjectContext db)
        {
            this.db = db;
        }

        [HttpGet()]

        public ActionResult getallproduct()
        {
           List<Product> pr = db.Products.ToList();
            List<ProductDTO> PRD = new List<ProductDTO>();
            foreach(Product product in pr) {

                ProductDTO productDTO = new ProductDTO()

                {
                    ProdId = product.ProdId,
                    ProdName = product.ProdName,
                    AdditionalDesc = product.AdditionalDesc,
                    Color = product.Color,
                    LongDesc = product.LongDesc,
                    ShortDesc = product.ShortDesc,
                };
                PRD.Add(productDTO);
            }

            return Ok(PRD);
        }
    }
}
