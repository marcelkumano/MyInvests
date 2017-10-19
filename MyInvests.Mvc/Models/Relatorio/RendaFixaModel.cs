using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyInvests.Mvc.Models.Relatorio
{
    public class RendaFixaModel
    {
        public RendaFixaModel()
        {
            Investimentos = new List<InvestimentosModel>();
        }
       public List<InvestimentosModel> Investimentos { get; set; }

        public class InvestimentosModel
        {
            public string Nome { get; set; }

            public DateTime DataCompra { get; set; }

            public DateTime DataVencimento { get; set; }

            public decimal ValorCompra { get; set; }

            public List<PosicaoInvestimentoModel> PosicaoInvestimento { get; set; }

        }

        public class PosicaoInvestimentoModel
        {
            public DateTime DataReferencia { get; set; }

            public decimal ValorBrutoAtual { get; set; }

            public decimal ValorLiquidoAtual { get; set; }

            public decimal ValorIR { get; set; }

            public decimal TaxaIR { get; set; }

            public decimal LucroLiquido { get; set; }

            public VariacaoDataAnterior Variacao { get; set; }

        }

        public class VariacaoDataAnterior
        {

            public decimal VariacaoValorLiquido { get; set; }

            public decimal VariacaoValorBruto { get; set; }

            public decimal PercentualVariacaoLiquida { get; set; }

            public decimal PercentualVariacaoBruta { get; set; }

        }
    }
}