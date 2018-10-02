using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OuroVerde.API.Maintenance.Data
{
    public class AMCaseTable : EntityBase
    {
        public string DataAreaId { get; set; }
        public string CaseId { get; set; }
        public string Description { get; set; }
        public string GroupId { get; set; }
        public string DeviceId { get; set; }
        public string CustAccount { get; set; }
        public string VendAccount { get; set; }
        public long WorkerResponsible { get; set; }
    }
}
