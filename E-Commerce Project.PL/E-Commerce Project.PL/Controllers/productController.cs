using E_Commerce.BL.DTO;
using E_Commerce.BL.UOW;
using E_Commerce.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;



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
        [Authorize]
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
                    ProductURL = productImageUrl,
                    Color = p.Color,
                    Size = p.Size,
                    CompanyName = p.CompanyName,
                };
                proddto.Add(prodto);

            }
            return Ok(proddto);
        }


        [HttpGet("{id}")]
        [Authorize]
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
                    Price = p.Price,
                    ProductURL = Url.Action("GetFile", "product", new { name = p.ProdId }),
                    Color = p.Color,
                    Size = p.Size,
                    CompanyName = p.CompanyName
                };
                return Ok(pdto);
            }
        }



        [HttpPost]
        
        public ActionResult add(Product product)
        {
            unit.ProductsRepository.add(product);
            unit.savechanges();
            return Ok();
        }


         [HttpDelete("{id}")]

 public ActionResult Deleteid(int id)
 {

     unit.ProductsRepository.delete(id);
     unit.savechanges();
     return Ok();
 }



        [HttpPut("{id}")]
[SwaggerOperation(Summary = "Method to update product", Description = "Update Product")]
public ActionResult Update(int id, [FromBody] ProductDTO productDTO)
{
    
    var existingProduct = unit.ProductsRepository.selectbyid(id);
    if (existingProduct == null)
    {
        return NotFound(); 
    }

    
    existingProduct.ProdName = productDTO.Name;
    existingProduct.ShortDesc = productDTO.Description;
    existingProduct.Color = productDTO.Color;
    existingProduct.Size = productDTO.Size;
    existingProduct.Price = productDTO.Price;
    existingProduct.CompanyName = productDTO.CompanyName;

   
    unit.ProductsRepository.update(existingProduct);

    try
    {
        unit.savechanges();
    }
    catch (Exception ex)
    {
        
        return StatusCode(StatusCodes.Status500InternalServerError, $"Error updating product: {ex.Message}");
    }

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

