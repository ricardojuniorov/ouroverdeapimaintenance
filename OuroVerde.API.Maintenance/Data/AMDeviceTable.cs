using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OuroVerde.API.Maintenance.Data
{
    public class AMDeviceTable : EntityBase
    {
        public string DataAreaId { get; set; }
        public string DeviceName { get; set; }
        public int MajorStatus { get; set; }
        public string DeviceId { get; set; }
        public string RegistrationNumber { get; set; }
        public string ClassId { get; set; }
    }
}
