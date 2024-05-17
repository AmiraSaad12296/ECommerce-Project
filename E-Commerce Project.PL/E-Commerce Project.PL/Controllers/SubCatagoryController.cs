using E_Commerce.BL.DTO;
using E_Commerce.BL.UOW;
using E_Commerce.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Project.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SubCatagoryController : ControllerBase
    {
        UnitOfWorks unit;

        public SubCatagoryController(UnitOfWorks unit)
        {
            this.unit = unit;
        }
        [HttpGet]

        public ActionResult GetAll()
        {
            List<SubCategory> Scat = unit.SubCatagoryRepository.selectall();
            List<SubCatagoryDTO> Scatdto = new List<SubCatagoryDTO>();

            foreach (SubCategory s in Scat)
            {
                SubCatagoryDTO Scatto = new SubCatagoryDTO()
                {
                    SubCatId = s.SubCatId,
                    SubCatName = s.SubCatName,
                    CreatedDate = DateTime.Now,
                    IsActive = s.IsActive,
                };
                Scatdto.Add(Scatto);

            }
            return Ok(Scatdto);
        }
        [HttpGet("{Subid}")]
        public ActionResult getproductpersubbyid(int Subid)
        {
            List<Product> p = unit.ProductsRepository.GetProductBySubcatId(Subid);
            if (p == null) return NotFound();

            var subcaDTO = p.Select(Product => new SubCatProdDTO
            {
                Id = Product.ProdId,
                SubCatId = Product.SubCatId,
                Name = Product.ProdName,
                Description = Product.ShortDesc,
                Price = Product.Price,
                ProductURL = Url.Action("GetFile", "product", new { name = Product.ProdId }),
                Color = Product.Color,
                Size = Product.Size,
                CompanyName = Product.CompanyName,
            }).ToList();

            return Ok(subcaDTO);
        }


        [HttpPost]
        [Authorize(Roles = "Admin")]
        public ActionResult add(SubCategory subCatagory)
        {
            unit.SubCatagoryRepository.add(subCatagory);
            unit.savechanges();
            return Created();
        }




        [HttpGet("GetSubCatById/{id}")]
        public ActionResult getbyid(int id)
        {
            SubCategory c = unit.SubCatagoryRepository.selectbyid(id);
            if (c == null) return NotFound();
            else
            {
                SubCatagoryDTO Scatto = new SubCatagoryDTO()
                {
                    SubCatId = c.SubCatId,
                    SubCatName = c.SubCatName,
                    CreatedDate = DateTime.Now,
                    IsActive = c.IsActive,
                    CategoryId = c.CategoryId
                };
                return Ok(Scatto);
            }
        }


        [HttpPut("{id}")]
        public ActionResult Update(int id, [FromBody] SubCategory subCategory)
        {
            var existingSubCategory = unit.SubCatagoryRepository.selectbyid(id);

            if (existingSubCategory == null)
            {
                return NotFound();
            }

            existingSubCategory.SubCatName = subCategory.SubCatName;
            existingSubCategory.CategoryId = subCategory.CategoryId;
            existingSubCategory.SubCatId = id;
            existingSubCategory.CreatedDate = DateTime.Now;

            unit.SubCatagoryRepository.update(existingSubCategory);
            unit.savechanges();

            return Ok();
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]

        public ActionResult Deleteid(int id)
        {
            
           
           unit.SubCatagoryRepository.delete(id);
            
            unit.savechanges();

            return Ok();

        }
    }

}

