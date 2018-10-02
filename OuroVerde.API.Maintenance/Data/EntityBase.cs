using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace OuroVerde.API.Maintenance.Data
{
    /// <summary>
    /// Entidade base
    /// </summary>
    public class EntityBase
    {
        /// <summary>
        /// ID 
        /// </summary>
        [Key]
        public long RecId { get; set; }

        /// <summary>
        /// Partição 
        /// </summary>
        public long Partition { get; set; }
    }
}
