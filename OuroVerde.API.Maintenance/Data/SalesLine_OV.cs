using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OuroVerde.API.Maintenance.Data
{
    public class SalesLine_OV : EntityBase
    {
        public string DataAreaId { get; set; }
        public string AMCaseId { get; set; }
        public string SalesQuotationId { get; set; }
        public Int64 SalesLine { get; set; }
        public decimal RefundValue { get; set; }
        public decimal RefundPercent { get; set; }
    }
}
