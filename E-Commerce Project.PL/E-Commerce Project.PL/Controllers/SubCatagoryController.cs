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
                    SubCatName = s.SubCatName,
                    CreatedDate = DateTime.Now,
                    IsActive = s.IsActive,
                };
                Scatdto.Add(Scatto);

            }
            return Ok(Scatdto);
        }
        [HttpGet("{id}")]
        public ActionResult getbyid(int id)
        {
            SubCategory s = unit.SubCatagoryRepository.selectbyid(id);
            if (s == null) return NotFound();
            else
            {
                SubCatagoryDTO Scatto = new SubCatagoryDTO()
                {
                    SubCatId = s.SubCatId,
                    SubCatName = s.SubCatName,
                    CreatedDate = DateTime.Now,
                    IsActive = s.IsActive,
                };
                return Ok(Scatto);
            }
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
