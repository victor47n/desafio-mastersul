using LogicaDeProgramacaoFrontEndWebEClasses.Models;
using System.Collections.Generic;

namespace LogicaDeProgramacaoFrontEndWebEClasses.Interfaces
{
    public interface IPaymentRepository
    {
        public List<Grid> GetPaymentsByUser(List<Grid> grid);
    }
}
