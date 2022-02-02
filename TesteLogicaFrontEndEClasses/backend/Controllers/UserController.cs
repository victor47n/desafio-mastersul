using LogicaDeProgramacaoFrontEndWebEClasses.Interfaces;
using LogicaDeProgramacaoFrontEndWebEClasses.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace LogicaDeProgramacaoFrontEndWebEClasses.Controllers
{
    [ApiController]
    [Route("v1/users")]
    public class UserController : ControllerBase
    {
        protected IUserRepository UserRepository;

        public UserController(IUserRepository userRepository)
        {
            UserRepository = userRepository;
        }

        /// <summary>
        /// Método responsável por buscar as informações dos usuários
        /// </summary>
        /// <returns><see cref="List{User}"/></returns>
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            var users = UserRepository.Get();

            return Ok(users);
        }
    }
}
