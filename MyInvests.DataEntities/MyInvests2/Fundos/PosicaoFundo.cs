using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInvests.DataEntities.MyInvests2.Fundos
{
    public class PosicaoFundo
    {
        public int IdFundo { get; set; }

        public virtual Fundo Fundo { get; set; }

        public DateTime DataReferencia { get; set; }

        public decimal ValorPorCota { get; set; }

    }
}
