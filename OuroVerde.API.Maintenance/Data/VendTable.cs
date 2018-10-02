using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OuroVerde.API.Maintenance.Data
{
    public class VendTable : EntityBase
    {
        public string DataAreaId { get; set; }
        public string AccountNum { get; set; }
        public string CNPJCPFNum_BR { get; set; }
        public long Party { get; set; }
    }
}
