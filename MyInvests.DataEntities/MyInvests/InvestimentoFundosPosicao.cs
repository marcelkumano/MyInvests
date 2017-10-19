using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInvests.DataEntities.MyInvests
{
    public class InvestimentoFundosPosicao
    {
        public InvestimentoFundosPosicao()
        {

        }

        public int Id { get; set; }
        
        public int? IdInvestimento { get; set; }

        public virtual InvestimentoFundos Investimento { get; set; }

        public DateTime DataReferencia { get; set; }

        public decimal ValorAtual { get; set; }

        public decimal ValorPorQuota { get; set; }

        public decimal ValorIR { get; set; }

        public decimal TaxaIR { get; set; }

        public DateTime DataAtualizacao { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1} - {2}", this.Id, this.DataReferencia.ToShortDateString(), this.ValorAtual.ToString("N2"));
        }
    }
}
    