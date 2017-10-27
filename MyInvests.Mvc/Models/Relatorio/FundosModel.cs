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

        }

    }
}