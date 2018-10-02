using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OuroVerde.API.Maintenance.Data
{
    public class InventTable : EntityBase
    {
        public string DataAreaId { get; set; }
        public string ItemId { get; set; }
        public Int64 Product { get; set; }
    }
}
