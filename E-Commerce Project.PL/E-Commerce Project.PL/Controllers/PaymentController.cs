using E_Commerce.BL.DTO;
using E_Commerce.BL.UOW;
using E_Commerce.DAL.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace E_Commerce_Project.PL.Controllers
{
   
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        UnitOfWorks unit;

        public PaymentController(UnitOfWorks unit)
        {
            this.unit = unit;
        }


        

        [HttpPost]
        [Consumes("application/json")]
        public IActionResult Add(PaymentDTO payment)
        {
           
            try
            {
                // Create a new Payment entity from the PaymentDTO
                var newPayment = new Payment
                {
                    Name = payment.name,
                    CardNo = payment.cardNo,
                    ExpDate = payment.expDate,
                    CVVNo = payment.ccVNo,
                    Address = payment.Address,
                    PaymentMode = payment.paymentMode
                };

                
                unit.PaymentsRepository.add(newPayment);
                unit.savechanges();

               
                return Created("", newPayment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while adding.. " + ex.Message);
            }
        }


        }
    }
