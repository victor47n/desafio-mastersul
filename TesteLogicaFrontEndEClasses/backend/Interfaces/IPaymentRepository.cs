using LogicaDeProgramacaoFrontEndWebEClasses.Models;
using System.Collections.Generic;

namespace LogicaDeProgramacaoFrontEndWebEClasses.Interfaces
{
    public interface IPaymentRepository
    {
        /// <summary>
        /// Método responsável por buscar as informações dos grid a partir 
        /// dos tipos passados por parâmetro.
        /// </summary>
        /// <param name="grid">Uma lista contendo os tipos dos grids</param>
        /// <returns><see cref="List{Grid}"/></returns>
        public List<Grid> GetPaymentsByUser(List<Grid> grid);
    }
}
