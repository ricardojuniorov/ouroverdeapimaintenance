using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using OuroVerde.API.Maintenance.View;

namespace OuroVerde.API.Maintenance.Data
{
    public class AX12Context : DbContext
    {
        public AX12Context(DbContextOptions options) : base(options)
        {

        }
        public DbSet<AMCaseTable> AMCaseTable { get; set; }
        public DbSet<AMCaseTableView> AMCaseTableView { get; set; }
        public DbSet<AMDeviceTable> AMDeviceTable { get; set; }
        public DbSet<DirPartyTable> DirPartyTable { get; set; }
        public DbSet<EcoResProductTranslation> EcoResProductTranslation { get; set; }
        public DbSet<HcmWorker> HcmWorker { get; set; }
        public DbSet<InventTable> InventTable { get; set; }
        public DbSet<SalesLine> SalesLine { get; set; }
        public DbSet<SalesLine_OV> SalesLine_OV { get; set; }
        public DbSet<VendTable> VendTable { get; set; }
    }
}
