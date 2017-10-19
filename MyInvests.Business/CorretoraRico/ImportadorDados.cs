using MyInvests.Business.CorretoraRico.JsonModel;
using MyInvests.DataAccess.DataContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInvests.Business.CorretoraRico
{
    public class ImportadorDados
    {
        public static void ImportarDadosRendaFixa(FixedIncomePosition jsonData)
        {
            List<DataEntities.MyInvests.InvestimentoRendaFixaPosicao> baseRendaFixa = LerDadosRendaFixa(jsonData);

            using (MyInvestsDataContext context = new MyInvestsDataContext())
            {

                /////ATUALIZAR OS INVESTIMENTOS
                //foreach (var registroAdicionar in baseRendaFixa.Select(x => x.Investimento))
                //{
                //    var registroDB = context.InvestimentoRendaFixa.Where(x => x.Id == registroAdicionar.Id).FirstOrDefault();

                //    if (registroDB == null)
                //    {
                //        registroDB = context.InvestimentoRendaFixa.Add(registroAdicionar);
                //        context.SaveChanges();
                //    }
                //}

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

        private static List<DataEntities.MyInvests.InvestimentoRendaFixaPosicao> LerDadosRendaFixa(FixedIncomePosition jsonData)
        {
            List<DataEntities.MyInvests.InvestimentoRendaFixaPosicao> baseInvestimentoRendaFixa = new List<DataEntities.MyInvests.InvestimentoRendaFixaPosicao>();

            foreach (var position in jsonData.positions)
            {
                DataEntities.MyInvests.InvestimentoRendaFixaPosicao novaPosicaoRF = new DataEntities.MyInvests.InvestimentoRendaFixaPosicao();

                novaPosicaoRF.DataAtualizacao = DateTime.Now;
                novaPosicaoRF.DataReferencia = position.referenceDate;
                novaPosicaoRF.ValorAtual = position.currentTotalGrossValue;
                novaPosicaoRF.ValorIR = position.irRate;
                novaPosicaoRF.TaxaIR = CalcularTaxaIR(position.buyTotalValue, position.currentTotalGrossValue, position.irRate);
                novaPosicaoRF.ValorPorUnidade = position.unitValue;
                novaPosicaoRF.IdInvestimento = position.order.id;

                novaPosicaoRF.Investimento = new DataEntities.MyInvests.InvestimentoRendaFixa();
                novaPosicaoRF.Investimento.Id = position.order.id;
                novaPosicaoRF.Investimento.Nome = position.order.offer.issuer.mnemonic;
                novaPosicaoRF.Investimento.Unidades = position.quantity;
                novaPosicaoRF.Investimento.ValorCompra = position.buyTotalValue;
                novaPosicaoRF.Investimento.DataCadastro = DateTime.Now;
                novaPosicaoRF.Investimento.DataCompra = position.order.dateOrder;
                novaPosicaoRF.Investimento.DataVencimento = position.order.offer.maturityDate;
                novaPosicaoRF.Investimento.IdCategoria = 1;

                baseInvestimentoRendaFixa.Add(novaPosicaoRF);
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
