using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInvests.DataEntities.MyInvests
{
    public class InvestimentoFundos
    {
        public InvestimentoFundos()
        {

        }
            
        public int Id { get; set; }

        public string Nome { get; set; }

        public int IdFundoRico { get; set; }

        public DateTime DataCompra { get; set; }

        public decimal ValorCompra { get; set; }

        public decimal Quotas { get; set; } 

        public DateTime DataCadastro { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", this.Id, this.Nome);
        }
    }
}
