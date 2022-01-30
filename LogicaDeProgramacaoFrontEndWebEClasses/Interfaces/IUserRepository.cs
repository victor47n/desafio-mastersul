using LogicaDeProgramacaoFrontEndWebEClasses.Models;
using System.Collections.Generic;

namespace LogicaDeProgramacaoFrontEndWebEClasses.Interfaces
{
    public interface IUserRepository
    {
        public List<User> Get();        
    }
}
