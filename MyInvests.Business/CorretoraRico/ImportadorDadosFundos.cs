using MyInvests.Business.CorretoraRico.JsonModel.Funds;
using MyInvests.Business.CorretoraRico.JsonModel.FundsOffer;
using MyInvests.DataAccess.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInvests.Business.CorretoraRico
{
    public class ImportadorDadosFundos
    {
        public static void Importar(FundsPosition jsonDataFunds, Offer jsonDataOffer)
        {
            List<DataEntities.MyInvests.InvestimentoRendaFixaPosicao> baseRendaFixa = LerDadosRendaFixa(jsonDataFunds, jsonDataOffer);

            using (MyInvestsDataContext context = new MyInvestsDataContext())
            {
                //ATUALIZAR AS POSICOES
                foreach (var posicaoRF in baseRendaFixa)
                {
                    var registroDB = context.InvestimentoRendaFixaPosicao
                                            .Where(x => x.IdInvestimento == posicaoRF.IdInvestimento && 
                                                        x.DataReferencia == posicaoRF.DataReferencia)
                                            .FirstOrDefault();

                    if (registroDB == null)
                    {
                        var investDB = context.InvestimentoRendaFixa.FirstOrDefault(x => x.Id == posicaoRF.IdInvestimento);

                        if (investDB != null)
                        {
                            posicaoRF.Investimento = investDB;
                        }

                        registroDB = context.InvestimentoRendaFixaPosicao.Add(posicaoRF);
                        context.SaveChanges();
                    }
                }
            }
        }

        private static List<DataEntities.MyInvests.InvestimentoFundosPosicao> LerDadosRendaFixa(FundsPosition jsonDataFunds, Offer jsonDataOffer)
        {
            List<DataEntities.MyInvests.InvestimentoFundosPosicao> baseInvestimentoRendaFixa = new List<DataEntities.MyInvests.InvestimentoFundosPosicao>();

            foreach (var fundosPosition in jsonDataFunds.positions)
            {
                foreach (var detail in fundosPosition.details)
                {
                    DataEntities.MyInvests.InvestimentoFundosPosicao novaPosicaoRF = new DataEntities.MyInvests.InvestimentoFundosPosicao();

                    novaPosicaoRF.DataAtualizacao = DateTime.Now;
                    novaPosicaoRF.Id = 0;
                    novaPosicaoRF.ValorAtual = detail.currentValueGross;
                    novaPosicaoRF.ValorIR = detail.incomeTax;

                    novaPosicaoRF.DataReferencia = 0;
                    novaPosicaoRF.ValorPorQuota = 0;
                    novaPosicaoRF.TaxaIR = 0;

                    novaPosicaoRF.Investimento = new DataEntities.MyInvests.InvestimentoFundos();
                    novaPosicaoRF.Investimento.IdFundoRico = fundosPosition.fund.id;
                    novaPosicaoRF.Investimento.Nome = position.order.offer.issuer.mnemonic;
                    novaPosicaoRF.Investimento.Unidades = position.quantity;
                    novaPosicaoRF.Investimento.ValorCompra = position.buyTotalValue;
                    novaPosicaoRF.Investimento.DataCadastro = DateTime.Now;
                    novaPosicaoRF.Investimento.DataCompra = position.order.dateOrder;
                    novaPosicaoRF.Investimento.DataVencimento = position.order.offer.maturityDate;
                    novaPosicaoRF.Investimento.IdCategoria = 1;

                    baseInvestimentoRendaFixa.Add(novaPosicaoRF);
                }
            }

            return baseInvestimentoRendaFixa;
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
