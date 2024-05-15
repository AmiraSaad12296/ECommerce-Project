using E_Commerce.BL.DTO;
using E_Commerce.BL.UOW;
using E_Commerce.DAL.Models;
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
                    SubCatId=s.SubCatId,
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
                    SubCatId =Product.SubCatId,
                    Name = Product.ProdName,
                    Description = Product.ShortDesc,
                    Price = Product.Price,
                    ProductURL = Url.Action("GetFile", "product", new { name = Product.ProdId }),
                    Color = Product.Color,
                    Size = Product.Size,
                    CompanyName =Product.CompanyName,
                }).ToList();
            
            return Ok(subcaDTO);
        }


        [HttpPost]

        public ActionResult add(SubCategory subCatagory)
        {
            unit.SubCatagoryRepository.add(subCatagory);
            unit.savechanges();
            return Created();
        }


        [HttpDelete]
        public ActionResult Deleteid(int id)
        {
            unit.SubCatagoryRepository.delete(id);
            unit.savechanges();
            return Ok("Deleted Successfully");
        }

        [HttpPut]
        public ActionResult Update([FromBody] SubCategory subCategory)
        {

            unit.SubCatagoryRepository.update(subCategory);
            unit.savechanges();
            return Ok("Updated Successfully");

        }
    }
}
