using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OuroVerde.API.Maintenance.Data
{
    public class EcoResProductTranslation : EntityBase
    {
        public Int64 Product { get; set; }
        public string Name { get; set; }
        public string LanguageId { get; set; }
    }
}
