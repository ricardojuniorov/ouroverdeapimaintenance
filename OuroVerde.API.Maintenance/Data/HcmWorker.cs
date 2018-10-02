using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OuroVerde.API.Maintenance.Data
{
    public class HcmWorker : EntityBase
    {
        public long Person { get; set; }

        public string PersonnelNumber { get; set; }


    }
}
