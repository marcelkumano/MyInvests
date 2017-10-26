using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInvests.Business.CorretoraRico.JsonModel.FundsOffer
{
    public class Offer
    {
        public int anbimaCode { get; set; }

        public int id { get; set; }

        public string name { get; set; }

        public string typeName { get; set; }

        public decimal netAssetValue { get; set; }

        public DateTime netAssetValueDate { get; set; }


    }
    
}
