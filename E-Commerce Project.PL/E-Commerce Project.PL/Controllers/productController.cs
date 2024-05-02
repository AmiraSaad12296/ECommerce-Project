using E_Commerce.DAL.Models;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using E_Commerce.BL.DTO;
using Swashbuckle.AspNetCore.Annotations;
using E_Commerce.BL.UOW;



namespace E_Commerce_Project.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class productController : ControllerBase
    {
        UnitOfWorks unit;

        public productController(UnitOfWorks unit)
        {
            this.unit = unit;
        }


        [HttpGet]
        [SwaggerOperation(Summary = "method to return all Products data", Description = "Products")]
        [SwaggerResponse(400, "if no product", Type = typeof(void))]
        [SwaggerResponse(200, "if found any Product", Type = typeof(List<ProductDTO>))]
        public ActionResult GetAll()
        {
            List<Product> prod = unit.ProductsRepository.selectall();
            List<ProductDTO> proddto = new List<ProductDTO>();

            foreach (Product p in prod)
            {
                string productImageUrl = Url.Action("GetFile", "product", new { name = p.ProdId });
                ProductDTO prodto = new ProductDTO()
                {
                    Id = p.ProdId,
                    Name = p.ProdName,
                    Description = p.ShortDesc,
                    Price = p.Price,
                    ProductURL= productImageUrl,
                    Color = p.Color,
                    Size = p.Size,
                    CompanyName = p.CompanyName,
                };
                proddto.Add(prodto);

            }
            return Ok(proddto);
        }


        [HttpGet("{id}")]
        [ProducesResponseType<ProductDTO>(200)]
        [ProducesResponseType(404)]
        public ActionResult getbyid(int id)
        {
           Product p = unit.ProductsRepository.selectbyid(id);
            if (p == null) return NotFound();
            else
            {
                ProductDTO pdto = new ProductDTO()
                {
                    Id = p.ProdId,
                    Name = p.ProdName,
                    Description = p.ShortDesc,
                    ProductURL= Url.Action("GetFile", "product", new { name = p.ProdId }),
                   Price = p.Price,
                    Color = p.Color,
                    Size = p.Size,
                    CompanyName = p.CompanyName
                };
                return Ok(pdto);
            }
        }



        [HttpPost]
        [SwaggerOperation(Summary = "method to Create new product", Description = "new Product")]
        [SwaggerResponse(201, "if product created", Type = typeof(void))]
        [SwaggerResponse(400, "if product not created ", Type = typeof(void))]
        [Consumes("application/json")]
        public ActionResult add(Product product)
        {
            unit.ProductsRepository.add(product);
            unit.savechanges();
            return Ok();
        }


        [HttpDelete]
        [SwaggerOperation(Summary = "method to Delete product", Description = "delete Product")]
        [SwaggerResponse(200, "if product deleted", Type = typeof(void))]
        public ActionResult Deleteid(int id)
        {
            unit.ProductsRepository.delete(id); 
            unit.savechanges();
            return Ok();
        }



        [HttpPut("{id}")]
        [SwaggerOperation(Summary = "method to Update product", Description = "Update Product")]
        public ActionResult Update( Product product)
        {
           
            unit.ProductsRepository.update(product);  
            unit.savechanges();
            return Ok();

        }


        [HttpGet("product-image/{name}")]
        public IActionResult GetFile(int name)
        {
            var fileName = $"{name}.png";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", "products", fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound(); // Handle file not found
            }

            var temporaryImage = System.IO.File.OpenRead(filePath);
            // Replace "image/png" with the correct mimetype of your image.
            return File(temporaryImage, "image/png");
        }







    }
}
