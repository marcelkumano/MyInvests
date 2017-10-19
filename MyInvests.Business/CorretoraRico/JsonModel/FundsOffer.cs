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

        public decimal netAssetValue { get; set; }

        public decimal netAssetValueDate { get; set; }

        public List<Position> positions { get; set; }

    }
    
}
