using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInvests.DataEntities.MyInvests2.Fundos
{
    public class Investimento
    {
        public int IdFundo { get; set; }

        public virtual Fundo Fundo { get; set; }

        public DateTime DataCompra { get; set; }

        public decimal QuantidadeCotas { get; set; }

        public decimal ValorIR { get; set; }

        public decimal ValorCompraCota { get; set; }
    }
}
