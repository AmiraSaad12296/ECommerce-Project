using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using E_Commerce.BL.DTO;
using E_Commerce.DAL.Models;
using Swashbuckle.AspNetCore.Annotations;
using E_Commerce.BL.UOW;

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
                CatagoryDTO catto = new CatagoryDTO()
                {
                    CatName = c.CatName,
                    CatImage =c.CatImage,
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
                    CatImage = c.CatImage,
                    CreatedDate = DateTime.Now,
                    IsActive = c.IsActive,
                };
                return Ok(catto);
            }
        }


        [HttpPost]
       
        public ActionResult add(Category catagory)
        {
            unit.CatagoryRepository.add(catagory);
            unit.savechanges();
            return Created();
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
    }
}
