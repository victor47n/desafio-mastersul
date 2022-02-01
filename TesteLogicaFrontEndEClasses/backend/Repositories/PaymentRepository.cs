using ClosedXML.Excel;
using LogicaDeProgramacaoFrontEndWebEClasses.Interfaces;
using LogicaDeProgramacaoFrontEndWebEClasses.Models;
using System.Collections.Generic;
using System.Linq;

namespace LogicaDeProgramacaoFrontEndWebEClasses.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        public List<Grid> GetPaymentsByUser(List<Grid> grids)
        {
            // Definindo qual arquivo vai ser aberto.
            // O arquivo deve permanecer fechado para que ele possa
            // ser utilizado pela aplicação.
            var xls = new XLWorkbook(@"Database\tables.xlsx");
            // Seleciona a aba que será utilizada no arquivo
            var woorksheet = xls.Worksheets.First(w => w.Name == "payments");
            var totalLines = woorksheet.Rows().Count();

            var payments = new List<Payment>();

            // A primeira linha representa o cabeçalho
            for (int count = 2; count <= totalLines; count++)
            {
                var payment = new Payment();

                payment.Id = int.Parse(woorksheet.Cell($"A{count}").Value.ToString());
                payment.Type = woorksheet.Cell($"B{count}").Value.ToString();
                payment.Value = decimal.Parse(woorksheet.Cell($"C{count}").Value.ToString());

                payments.Add(payment);
            }

            for (int count = 0; count < grids.Count; count++)
            {
                // Popula as informações de pagamento a partir das informações consumidas do arquivo xlsx
                // quando o tipo do pagamento é igual ao tipo de pagamento do grid vindo do parâmetro
                grids[count].Payments = payments.Select(x => x).Where(x => x.Type == grids[count].Type).ToList(); ;
            }

            return grids;
        }
    }
}
