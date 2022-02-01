using LogicaDeProgramacaoFrontEndWebEClasses.Models;
using System.Collections.Generic;

namespace LogicaDeProgramacaoFrontEndWebEClasses.Interfaces
{
    public interface IUserRepository
    {
        /// <summary>
        /// Método responsável por consumir as informações de um arquivo xlsx
        /// e retornar as informações de todos os usuários do arquivo
        /// </summary>
        /// <returns><see cref="List{User}"/></returns>
        public List<User> Get();

        /// <summary>
        /// Método responsável por consumir as informações de um arquivo xlsx
        /// e retornar as informações de um usuário
        /// do id do usuário
        /// </summary>
        /// <param name="id">Identificação do usuário</param>
        /// <returns><see cref="User"/></returns>
        public User GetUserById(int id);        
    }
}
