using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInvests.DataEntities.MyInvests2.Fundos
{
    public class Fundo
    {
        public int Id { get; set; }

        public string Nome { get; set; }

        public string DescricaoTipo { get; set; }

        public DateTime DataAtualizacao { get; set; }

    }
}
