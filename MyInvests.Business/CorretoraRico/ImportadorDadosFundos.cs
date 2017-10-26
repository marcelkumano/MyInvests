using MyInvests.Business.CorretoraRico.JsonModel.Funds;
using MyInvests.Business.CorretoraRico.JsonModel.FundsOffer;
using MyInvests.DataAccess.DataContexts;
using MyInvests.DataEntities.MyInvests2.Fundos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInvests.Business.CorretoraRico
{
    public class ImportadorDadosFundos
    {
        private List<Offer> ListaOfertasFundo { get; set; }

        private FundsPosition PosicaoFundos { get; set; }

        public void Importar(FundsPosition jsonDataFunds, List<Offer> jsonDataOffer)
        {
            ListaOfertasFundo = jsonDataOffer;
            PosicaoFundos = jsonDataFunds;

            List<Investimento> investimentosRico = ObterInformacaoInvestimentos();

            using (MyInvestsDataContext context = new MyInvestsDataContext())
            {
                //ATUALIZAR AS POSICOES
                foreach (var investimento in investimentosRico)
                {
                    investimento.Fundo = ObterInformacoesFundo(investimento.IdFundo);

                    var registroDB = context.FundosInvestimento
                                            .Where(x => x.IdFundo == investimento.IdFundo &&
                                                        x.DataCompra == investimento.DataCompra)
                                            .FirstOrDefault();


                    //SALVAR O INVESTIMENTO
                    if (registroDB == null)
                    {
                        var fundoDB = context.Fundos.FirstOrDefault(x => x.Id == investimento.IdFundo);

                        //se o fundo ja existir usar o que tem na base
                        if (fundoDB != null)
                        {
                            investimento.Fundo = fundoDB;
                        }

                        registroDB = context.FundosInvestimento.Add(investimento);
                        context.SaveChanges();
                    }
                    else
                    {
                        registroDB.ValorIR = investimento.ValorIR;
                        context.SaveChanges();
                    }


                    //SALVAR A POSICAO DO FUNDO
                    var posicaoFundo = ObterInformacoesPosicao(investimento.IdFundo);

                    var posicaoDB = context.FundosPosicao
                                           .Where(x => x.IdFundo == posicaoFundo.IdFundo &&
                                                       x.DataReferencia == posicaoFundo.DataReferencia)
                                           .FirstOrDefault();

                    if (posicaoDB == null)
                    {
                        var fundoDB = context.Fundos.FirstOrDefault(x => x.Id == investimento.IdFundo);

                        //se o fundo ja existir usar o que tem na base
                        if (fundoDB != null)
                        {
                            posicaoFundo.Fundo = fundoDB;
                        }

                        context.FundosPosicao.Add(posicaoFundo);
                        context.SaveChanges();
                    }
                }
            }
        }

        private List<Investimento> ObterInformacaoInvestimentos()
        {
            List<Investimento> investimentosFundos = new List<Investimento>();

            foreach (var fundosPosition in this.PosicaoFundos.positions)
            {
                foreach (var detail in fundosPosition.details)
                {
                    Investimento novoInvestimento = new Investimento();

                    novoInvestimento.IdFundo = fundosPosition.fund.id;
                    novoInvestimento.DataCompra = detail.date;
                    novoInvestimento.QuantidadeCotas = detail.buyTotalQuantity;
                    novoInvestimento.ValorCompraCota = detail.quoteValue;
                    novoInvestimento.ValorIR = detail.incomeTax;

                    investimentosFundos.Add(novoInvestimento);
                }
            }

            return investimentosFundos;
        }

        public Fundo ObterInformacoesFundo(int idFund)
        {
            var obj = this.ListaOfertasFundo.Where(x => x.id == idFund).FirstOrDefault();

            if (obj == null)
            {
               return new Fundo();
            }

            return new Fundo()
            {
                Id = obj.id,
                Nome = obj.name,
                DescricaoTipo = obj.typeName,
                DataAtualizacao = DateTime.Now
            };
        }

        public PosicaoFundo ObterInformacoesPosicao(int idFund)
        {
            var obj = this.ListaOfertasFundo.Where(x => x.id == idFund).FirstOrDefault();

            if (obj == null)
            {
                return new PosicaoFundo();
            }

            return new PosicaoFundo()
            {
                IdFundo = obj.id,
                DataReferencia = obj.netAssetValueDate,
                ValorPorCota = obj.netAssetValue
            };
        }

        private static decimal CalcularTaxaIR(decimal valorCompra, decimal valorAtual, decimal valorIR)
        {
            var lucro = valorAtual - valorCompra;

            if (lucro > 0)
            {
                return Math.Round(valorIR / lucro, 3);
            }

            return 0M;
        }
    }
}
