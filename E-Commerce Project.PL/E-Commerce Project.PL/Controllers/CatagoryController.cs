using E_Commerce.BL.DTO;
using E_Commerce.BL.UOW;
using E_Commerce.DAL.Models;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Project.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatagoryController : ControllerBase
    {
        UnitOfWorks unit;

        public CatagoryController(UnitOfWorks unit)
        {
            this.unit = unit;
        }



        [HttpGet]

        public ActionResult GetAll()
        {

            List<Category> cat = unit.CatagoryRepository.selectall();
            List<CatagoryDTO> catdto = new List<CatagoryDTO>();

            foreach (Category c in cat)
            {
                string CatImageUrl = Url.Action("GetFile", "Catagory", new { name = c.CatId });
                CatagoryDTO catto = new CatagoryDTO()
                {
                     CatId=c.CatId,
                    CatName = c.CatName,
                    CatImage = CatImageUrl,
                    CreatedDate = DateTime.Now,
                    IsActive = c.IsActive,
                };
                catdto.Add(catto);

            }
            return Ok(catdto);
        }


        [HttpGet("{id}")]
        public ActionResult getbyid(int id)
        {
            Category c = unit.CatagoryRepository.selectbyid(id);
            if (c == null) return NotFound();
            else
            {
                CatagoryDTO catto = new CatagoryDTO()
                {
                    CatName = c.CatName,
                    CatImage = Url.Action("GetFile", "Catagory", new { name = c.CatId }),
                    CreatedDate = DateTime.Now,
                    IsActive = c.IsActive,
                };
                return Ok(catto);
            }
        }


        [HttpPost]


        public ActionResult Add(Category category, IFormFile imageFile)
        {
            try
            {
                if (imageFile != null && imageFile.Length > 0)
                {
                    var fileName = Guid.NewGuid().ToString() + Path.GetExtension(imageFile.FileName);
                    var filePath = Path.Combine("wwwroot/images", fileName);

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        imageFile.CopyTo(stream);
                    }

                    category.CatImage = fileName;
                }
                unit.CatagoryRepository.add(category);
                unit.savechanges();

                return Created();
            }
            catch (Exception ex)
            {

                return StatusCode(500, $"Internal server error: {ex}");
            }
        }
        [HttpDelete]
        public ActionResult Deleteid(int id)
        {
            unit.CatagoryRepository.delete(id);
            unit.savechanges();
            return Ok("Deleted Successfully");
        }

        [HttpPut]
        public ActionResult Update([FromBody] Category category)
        {

            unit.CatagoryRepository.update(category);
            unit.savechanges();
            return Ok("Updated Successfully");

        }

        [HttpGet("Catagory-image/{name}")]
        public IActionResult GetFile(int name)
        {
            var fileName = $"{name}.jpg";
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "image", "Catagory", fileName);

            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var temporaryImage = System.IO.File.OpenRead(filePath);

            return File(temporaryImage, "image/jpg");
        }

    }
}
