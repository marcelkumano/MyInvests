using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInvests.DataEntities.MyInvests
{
    public class InvestimentoRendaFixa
    {
        public InvestimentoRendaFixa()
        {

        }
            
        public int Id { get; set; }

        public string Nome { get; set; }

        public DateTime DataCompra { get; set; }

        public DateTime? DataVencimento { get; set; }

        public decimal ValorCompra { get; set; }

        public double Unidades { get; set; } 

        public int IdCategoria { get; set; }

        public virtual CategoriaInvestimento Categoria { get; set; }

        public DateTime DataCadastro { get; set; }

        public override string ToString()
        {
            return string.Format("{0} - {1}", this.Id, this.Nome);
        }
    }
}
