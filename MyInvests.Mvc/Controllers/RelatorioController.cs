using MyInvests.DataAccess.DataContexts;
using MyInvests.Mvc.Models.Relatorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyInvests.Mvc.Controllers
{
    public class RelatorioController : Controller
    {
        // GET: Relatorio
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Fundos()
        {
            FundosModel model = new FundosModel();

            using (MyInvestsDataContext context = new MyInvestsDataContext())
            {
                foreach (var itemFundoDB in context.Fundos.ToList())
                {

                    context.FundosInvestimento.GroupBy( i => i.IdFundo, )

                    FundosModel.InvestimentosModel investModel = new FundosModel.InvestimentosModel();


                    investModel.DataCompra = ;
                    investModel.Nome = ;
                    investModel.RendimentoBruto = ;
                    investModel.RendimentoLiquido = ;
                    investModel.TaxaIR = ;
                    investModel.TaxaRendimentoBruto = ;
                    investModel.TaxaRendimentoLiquido = ;
                    investModel.Tipo = ;
                    investModel.ValorAtualBruto = ;
                    investModel.ValorAtualLiquido = ;
                    investModel.ValorCompra = ;
                    investModel.ValorIR = ;

                }
            }

            return PartialView(model);
        }

        public ActionResult RendaFixa()
        {
            RendaFixaModel model = new RendaFixaModel();
            model.Investimentos = new List<RendaFixaModel.InvestimentosModel>();

            using (MyInvestsDataContext context = new MyInvestsDataContext())
            {
                foreach (var investEntDB in context.InvestimentoRendaFixa.ToList())
                {
                    RendaFixaModel.InvestimentosModel novoModelInvestimento = new RendaFixaModel.InvestimentosModel();

                    novoModelInvestimento.Nome = investEntDB.Nome;
                    novoModelInvestimento.DataCompra = investEntDB.DataCompra;
                    novoModelInvestimento.DataVencimento = investEntDB.DataVencimento.Value;
                    novoModelInvestimento.ValorCompra = investEntDB.ValorCompra;

                    novoModelInvestimento.PosicaoInvestimento =
                        context.InvestimentoRendaFixaPosicao.Where(x => x.IdInvestimento == investEntDB.Id)
                                                            .Select(x => new RendaFixaModel.PosicaoInvestimentoModel() {
                                                                DataReferencia = x.DataReferencia,
                                                                TaxaIR = x.TaxaIR,
                                                                ValorBrutoAtual = x.ValorAtual,
                                                                ValorIR = x.ValorIR,
                                                                ValorLiquidoAtual = x.ValorAtual - x.ValorIR,
                                                                LucroLiquido = x.ValorAtual - investEntDB.ValorCompra
                                                            })
                                                            .OrderByDescending(x => x.DataReferencia)
                                                            .ToList();

                    for (int i = 0; i < novoModelInvestimento.PosicaoInvestimento.Count(); i++)
                    {
                        RendaFixaModel.VariacaoDataAnterior variacao = new RendaFixaModel.VariacaoDataAnterior();

                        var posicaoAtual = novoModelInvestimento.PosicaoInvestimento.ElementAtOrDefault(i);
                        var posicaoAnterior = novoModelInvestimento.PosicaoInvestimento.ElementAtOrDefault(i + 1);

                        if (posicaoAnterior != null)
                        {
                            variacao.VariacaoValorBruto = posicaoAtual.ValorBrutoAtual -
                                                          posicaoAnterior.ValorBrutoAtual;

                            variacao.VariacaoValorLiquido = posicaoAtual.ValorBrutoAtual -
                                                            posicaoAnterior.ValorBrutoAtual;

                            variacao.PercentualVariacaoBruta = variacao.VariacaoValorBruto  / posicaoAnterior.ValorBrutoAtual;

                            variacao.PercentualVariacaoLiquida = variacao.VariacaoValorLiquido / posicaoAnterior.ValorLiquidoAtual;
                        }

                        novoModelInvestimento.PosicaoInvestimento[i].Variacao = variacao;
                    }

                    model.Investimentos.Add(novoModelInvestimento);
                }
            }

            return PartialView(model);
        }
    }
}