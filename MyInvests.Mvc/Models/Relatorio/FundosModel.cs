using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyInvests.Mvc.Models.Relatorio
{
    public class FundosModel
    {
        public FundosModel()
        {
            Investimentos = new List<InvestimentosModel>();
        }

        public List<InvestimentosModel> Investimentos { get; set; }

        public class InvestimentosModel
        {
            public InvestimentosModel()
            {
                HistoricoPosicoes = new List<PosicaoFundoModel>();
            }

            public string Nome { get; set; }

            public string Tipo { get; set; }

            public DateTime DataReferenciaPosicao { get; set; }

            public DateTime DataCompra { get; set; }

            public decimal ValorCompra { get; set; }

            public decimal ValorAtualBruto { get; set; }

            public decimal ValorIR { get; set; }

            public decimal TaxaIR { get; set; }

            public decimal ValorAtualLiquido { get; set; }

            public decimal RendimentoBruto { get; set; }

            public decimal TaxaRendimentoBruto { get; set; }

            public decimal RendimentoLiquido { get; set; }

            public decimal TaxaRendimentoLiquido { get; set; }

            public List<PosicaoFundoModel> HistoricoPosicoes { get; set; }

        }

        public class PosicaoFundoModel
        {
            public DateTime DataReferencia { get; set; }

            public decimal ValorCota { get; set; }

            public decimal ValorTotalBruto { get; set; }

            public decimal ValorVariacaoBruto { get; set; }

            public decimal TaxaVariacao { get; set; }
        }

    }
}