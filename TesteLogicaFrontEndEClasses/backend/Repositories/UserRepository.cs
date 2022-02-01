using ClosedXML.Excel;
using LogicaDeProgramacaoFrontEndWebEClasses.Interfaces;
using LogicaDeProgramacaoFrontEndWebEClasses.Models;
using System.Collections.Generic;
using System.Linq;

namespace LogicaDeProgramacaoFrontEndWebEClasses.Repositories
{
    public class UserRepository : IUserRepository
    {
        public List<User> Get()
        {
            // Definindo qual arquivo vai ser aberto.
            // O arquivo deve permanecer fechado para que ele possa
            // ser utilizado pela aplicação.
            var xls = new XLWorkbook(@"Database\tables.xlsx");
            // Seleciona a aba que será utilizada no arquivo
            var woorksheet = xls.Worksheets.First(w => w.Name == "users");
            var totalLines = woorksheet.Rows().Count();

            var users = new List<User>();

            // A primeira linha representa o cabeçalho
            for (int count = 2; count <= totalLines; count++)
            {
                var user = new User();

                user.Grids = new();

                user.Id = int.Parse(woorksheet.Cell($"A{count}").Value.ToString());
                user.Name = woorksheet.Cell($"B{count}").Value.ToString();

                user.Grids.Add(new Grid() { Type = woorksheet.Cell($"C{count}").Value.ToString() });
                user.Grids.Add(new Grid() { Type = woorksheet.Cell($"D{count}").Value.ToString() });
                user.Grids.Add(new Grid() { Type = woorksheet.Cell($"E{count}").Value.ToString() });

                users.Add(user);
            }

            return users;
        }

        public User GetUserById(int id)
        {
            var xls = new XLWorkbook(@"Database\tables.xlsx");
            // Seleciona a aba que será utilizada no arquivo
            var woorksheet = xls.Worksheets.First(w => w.Name == "users");
            var totalLines = woorksheet.Rows().Count();

            var user = new User();

            // A primeira linha representa o cabeçalho
            for (int count = 2; count <= totalLines; count++)
            {
                int idRow = int.Parse(woorksheet.Cell($"A{count}").Value.ToString());
                if (id == idRow)
                {
                    user.Grids = new();

                    user.Id = idRow;
                    user.Name = woorksheet.Cell($"B{count}").Value.ToString();

                    user.Grids.Add(new Grid() { Type = woorksheet.Cell($"C{count}").Value.ToString() });
                    user.Grids.Add(new Grid() { Type = woorksheet.Cell($"D{count}").Value.ToString() });
                    user.Grids.Add(new Grid() { Type = woorksheet.Cell($"E{count}").Value.ToString() });

                    break;
                }
            }

            return user;
        }
    }
}
