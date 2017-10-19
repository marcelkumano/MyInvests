using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyInvests.Business.CorretoraRico.JsonModel.Funds
{



    public class FundsPosition
    {
        public decimal buyTotalValue { get; set; }

        public decimal currentTotalGrossValue { get; set; }

        public decimal currentTotalNetValue { get; set; }

        public List<Position> positions { get; set; }

    }

    public class Position
    {
        public decimal currentTotalQuantity { get; set; }
        public decimal currentTotalValue { get; set; }
        public decimal currentTotalValueGross { get; set; }
        public decimal currentTotalValueNet { get; set; }
        public decimal incomeTax { get; set; }
        public decimal percentTotalGrossValue { get; set; }
        public decimal transactionTax { get; set; }
        public decimal variation { get; set; }
        public List<Detail> details { get; set; }
        public Fund fund { get; set; }
    }

    public class Detail
    {
        public decimal applicationValue { get; set; }
        public decimal buyTotalQuantity { get; set; }
        public decimal currentValueGross { get; set; }
        public DateTime date { get; set; }
        public decimal incomeTax { get; set; }
        public string movementType { get; set; }
        public decimal netWorth { get; set; }

    }

    public class Fund
    {
        public int anbimaCode { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        
        public string typeName { get; set; }

    }
}
