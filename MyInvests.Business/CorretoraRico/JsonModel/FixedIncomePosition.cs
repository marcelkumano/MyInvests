using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInvests.Business.CorretoraRico.JsonModel
{
    public class FixedIncomePosition
    {
        public decimal buyTotalValue { get; set; }

        public decimal currentTotalGrossValue { get; set; }

        public List<Position> positions { get; set; }

    }

    public class Position
    {
        public int id { get; set; }
        public decimal currentTotalGrossValue { get; set; }
        public decimal buyTotalValue { get; set; }
        public decimal irRate { get; set; }
        public double quantity { get; set; }
        public DateTime referenceDate { get; set; }
        public decimal totalGrossPercentage { get; set; }
        public decimal unitValue { get; set; }

        public Order order { get; set; }
        
    }

    public class Order
    {
        public int id { get; set; }
        public DateTime creationDate { get; set; }

        public DateTime dateOrder { get; set; }

        public decimal grossValue { get; set; }

        public decimal liquidValue { get; set; }
        
        public decimal unitValue { get; set; }

        public Offer offer { get; set; }
    }

    public class Offer
    {
        public string buyInterestRateDescription { get; set; }

        public DateTime maturityDate { get; set; }
        public int maturityDays { get; set; }

        public Issuer issuer { get; set; }
    }

    public class Issuer
    {
        public string mnemonic { get; set; }

        public string name { get; set; }

        public string rating { get; set; }

    }
}
