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
        public ActionResult ImportarArquivos(IEnumerable<HttpPostedFileBase> files)
        {
            foreach (HttpPostedFileBase file in files)
            {
                if (file!= null &&
                    file.ContentLength > 0)
                {
                    // get contents to string
                    string str = (new StreamReader(file.InputStream)).ReadToEnd();

                    // deserializes string into object
                    JavaScriptSerializer jss = new JavaScriptSerializer();
                    var d = jss.Deserialize<FixedIncomePosition>(str);

                    Business.CorretoraRico.ImportadorDados.ImportarDadosRendaFixa(d);
                    // once it's an object, you can use do with it whatever you want
                }
            }

            return View();
        }
    }
}