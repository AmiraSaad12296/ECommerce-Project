using E_Commerce.BL.DTO;
using E_Commerce.BL.UOW;
using E_Commerce.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;

namespace E_Commerce_Project.PL.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        UnitOfWorks unit;

        public ContactController(UnitOfWorks unit)
        {
            this.unit = unit;
        }

        
        [HttpGet]
        [Authorize(Roles = "Admin")]
        public ActionResult GetAll()
        {
            List<Contact> contacts = unit.ContactRepository.selectall();

            if (contacts == null) { return NotFound();}
            else
            {
                return Ok(contacts);
            }
        }

        [HttpPost]
        public ActionResult add(Contact C)
            {
            unit.ContactRepository.add(C);
            unit.savechanges();
            return Created();
        }
        }
    }

