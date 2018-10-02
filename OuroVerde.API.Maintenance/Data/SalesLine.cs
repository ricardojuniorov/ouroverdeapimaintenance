using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OuroVerde.API.Maintenance.Data
{
    public class SalesLine : EntityBase
    {
        public string DataAreaId { get; set; }
        public string ItemId { get; set; }
        public decimal SalesQty { get; set; }
        public string SalesUnit { get; set; }
        public decimal SalesPrice { get; set; }
        public decimal LineDisc { get; set; }
        public decimal LinePercent { get; set; }
        public decimal LineAmount { get; set; }
        public decimal RefundValue { get; set; }
        public decimal RefundPercent { get; set; }
        public string Name { get; set; }
    }
}
