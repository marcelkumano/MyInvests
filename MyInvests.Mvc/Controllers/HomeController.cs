using MyInvests.Business.CorretoraRico.JsonModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;

namespace MyInvests.Mvc.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            //MyInvests.Business.Class1.Teste();

            return View();
        }

        [HttpPost]
        public ActionResult ImportarArquivoRendaFixa(HttpPostedFileBase file)
        {
            if (file != null &&
                file.ContentLength > 0)
            {
                // get contents to string
                string str = (new StreamReader(file.InputStream)).ReadToEnd();

                // deserializes string into object
                JavaScriptSerializer jss = new JavaScriptSerializer();
                var d = jss.Deserialize<FixedIncomePosition>(str);

                Business.CorretoraRico.ImportadorDadosRendaFixa.Importar(d);
            }

            return View("SucessoImportacao");
        }

        [HttpPost]
        public ActionResult ImportarArquivoFundosInvestimento(List<HttpPostedFileBase> files)
        {
            HttpPostedFileBase filePosition = files.FirstOrDefault(x => x.FileName.Contains("pos"));
            HttpPostedFileBase fileOffer = files.FirstOrDefault(x => x.FileName.Contains("off"));

            if (filePosition != null && fileOffer != null)
            {
                JavaScriptSerializer jss = new JavaScriptSerializer();

                // get contents to string
                string strPosition = (new StreamReader(filePosition.InputStream)).ReadToEnd();
                // deserializes string into object
                var position = jss.Deserialize<MyInvests.Business.CorretoraRico.JsonModel.Funds.FundsPosition>(strPosition);

                // get contents to string
                string strOffer = (new StreamReader(fileOffer.InputStream)).ReadToEnd();
                // deserializes string into object
                var offer = jss.Deserialize<MyInvests.Business.CorretoraRico.JsonModel.FundsOffer.Offer>(strOffer);

                Business.CorretoraRico.ImportadorDadosFundos.Importar(position, offer);
            }

            return View("SucessoImportacao");
        }
    }

}