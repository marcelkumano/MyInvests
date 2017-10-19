using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInvests.DataEntities.MyInvests
{
    public class CategoriaInvestimento
    {
        public CategoriaInvestimento()
        {

        }

        public int Id { get; set; }

        public string Nome { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", this.Id, this.Nome);
        }
    }
}
