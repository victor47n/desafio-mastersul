using LogicaDeProgramacaoFrontEndWebEClasses.Interfaces;
using LogicaDeProgramacaoFrontEndWebEClasses.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LogicaDeProgramacaoFrontEndWebEClasses.Controllers
{
    [Route("v1/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        protected IPaymentRepository PaymentRepository;

        public PaymentController(IPaymentRepository paymentRepository)
        {
            PaymentRepository = paymentRepository;
        }

        [HttpGet]
        public ActionResult<Grid> GetPaymentsByUser([FromBody] List<Grid> grids)
        {
            grids = PaymentRepository.GetPaymentsByUser(grids);

            return grids == null ? NotFound() : Ok(grids);
        }
    }
}
