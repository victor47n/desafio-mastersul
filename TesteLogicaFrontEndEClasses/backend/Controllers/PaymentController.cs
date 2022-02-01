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
        protected IUserRepository UserRepository;

        public PaymentController(IPaymentRepository paymentRepository, IUserRepository userRepository)
        {
            PaymentRepository = paymentRepository;
            UserRepository = userRepository;
        }

        /// <summary>
        /// Método responsável por buscar as informações dos grid a partir 
        /// do id do usuário
        /// </summary>
        /// <param name="id">Identificação do usuário</param>
        /// <returns><see cref="List{Grid}"/></returns>
        [HttpGet("{id}")]
        public ActionResult<List<Grid>> GetPaymentsByUserId([FromRoute] int id)
        {
            User user = UserRepository.GetUserById(id);
            List<Grid> grids = PaymentRepository.GetPaymentsByUser(user.Grids);

            return grids == null ? NotFound() : Ok(grids);
        }
    }
}
