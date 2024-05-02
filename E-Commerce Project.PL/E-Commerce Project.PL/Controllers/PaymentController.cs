using E_Commerce.BL.DTO;
using E_Commerce.BL.UOW;
using E_Commerce.DAL.Models;
using Microsoft.AspNetCore.Http;
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


        [HttpGet]
        public IActionResult getAll()
        {
            List<Payment> payments = unit.PaymentsRepository.selectall();

            if (payments == null || payments.Count == 0)
            {
                return NotFound("No payments found.");
            }

            List<PaymentDTO> dtos = new List<PaymentDTO>();

            foreach (Payment p in payments)
            {
                PaymentDTO dto = new PaymentDTO()
                {
                    paymentId = p.PaymentId,
                    cardNo = p.CardNo,
                    expDate = p.ExpDate,
                    name = p.Name,
                    PaymentMode = p.PaymentMode                 
                };
                dtos.Add(dto);
            }
            return Ok(dtos);
        }

        [HttpGet("{id}")]
        public IActionResult getById(int id)
        {
            Payment payment = unit.PaymentsRepository.selectbyid(id);
            if (payment == null) return NotFound();

            PaymentDTO dto = new PaymentDTO()
            {
                PaymentMode = payment.PaymentMode,
                expDate = payment.ExpDate,
                name = payment.Name,
                cardNo= payment.CardNo,
                paymentId = payment.PaymentId
            };
            return Ok(dto);
        }

         /*{
          "name": "string",
          "cardNo": 0,
          "expDate": "string",
          "cvvNo": "string",
          "address": "string",
          "paymentMode": "string"
        } */
        [HttpPost]
        [Consumes("application/json")]
        public IActionResult add(Payment payment)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                unit.PaymentsRepository.add(payment);
                unit.savechanges();
                return Created("", payment);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "An error occurred while adding.. " + ex.Message);
            }
        }

        [HttpPut]
        [Consumes("application/json")]
        public ActionResult update(Payment payment)
        {

            unit.PaymentsRepository.update(payment);
            unit.savechanges();
            return Ok();
        }

        [HttpDelete]
        public ActionResult delete(int id)
        {
            unit.PaymentsRepository.delete(id);
            unit.savechanges();
            return Ok();
        }

    }
}
