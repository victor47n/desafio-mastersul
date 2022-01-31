using System.Collections.Generic;

namespace LogicaDeProgramacaoFrontEndWebEClasses.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Grid> Grids { get; set; }
    }
}