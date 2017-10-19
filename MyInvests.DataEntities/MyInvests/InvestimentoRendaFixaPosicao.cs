using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInvests.DataEntities.MyInvests
{
    public class InvestimentoRendaFixaPosicao
    {
        public InvestimentoRendaFixaPosicao()
        {

        }

        public int Id { get; set; }
        
        public int? IdInvestimento { get; set; }

        public virtual InvestimentoRendaFixa Investimento { get; set; }

        public DateTime DataReferencia { get; set; }

        public decimal ValorAtual { get; set; }

        public decimal ValorPorUnidade { get; set; }

        public decimal ValorIR { get; set; }

        public decimal TaxaIR { get; set; }

        public DateTime DataAtualizacao { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2}", this.Id, this.DataReferencia.ToShortDateString(), this.ValorAtual.ToString("N2"));
        }
    }
}
    