using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OuroVerde.API.Maintenance.Data;
using OuroVerde.API.Maintenance.View;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;

namespace OuroVerde.API.Maintenance.Queries
{
    public class AMCaseQuery : IAMCaseQuery
    {
        private List<string> _dataAreaId;
        private long _partition;
        private readonly AX12Context _db;
        public AMCaseQuery(AX12Context db, IConfiguration configuration)
        {
            _db = db;
            _dataAreaId = string.IsNullOrEmpty(configuration["AxConfig:DataAreaId"]) ? null : configuration["AxConfig:DataAreaId"].Split(",").ToList();
            _partition = Convert.ToInt64(configuration["AxConfig:Partition"]);
        }

        public async Task<IEnumerable<AMCaseTableView>> GetStored(string vendAccount)
        {
            var pVendAccount = new SqlParameter("@VendAccount", vendAccount);

            var items = _db.AMCaseTableView.FromSql("API_Maintenance_AMCase @VendAccount", pVendAccount).ToList();

            return items;
        }

        public async Task<IEnumerable<AMCaseTableView>> Get(string vendAccount)
        {
            var query = _db.AMCaseTable.Join(_db.AMDeviceTable, caseTable => new { Partition = caseTable.Partition, DataAreaId = caseTable.DataAreaId, DeviceId = caseTable.DeviceId },
                                                                   device => new { device.Partition, device.DataAreaId, device.DeviceId }, (caseTable, device) => new { caseTable, device })
                                                .Join(_db.VendTable, casetable => new { Partition = casetable.caseTable.Partition, DataAreaId = casetable.caseTable.DataAreaId, AccountNum = casetable.caseTable.VendAccount },
                                                                          vend => new { vend.Partition, vend.DataAreaId, vend.AccountNum }, (caseTable, vend) => new { caseTable, vend })
                                                        .Join(_db.DirPartyTable, vend => new { Partition = vend.vend.Partition, RecId = vend.vend.Party },
                                                                                 dirParty => new { dirParty.Partition, dirParty.RecId }, (vend, dirParty) => new { vend, dirParty })
                                                                .Join(_db.HcmWorker, casetable => new { Partition = casetable.vend.caseTable.caseTable.Partition, RecId = casetable.vend.caseTable.caseTable.WorkerResponsible },
                                                                                        worker => new { worker.Partition, worker.RecId }, (casetable, worker) => new { casetable, worker })
                                                                                                .Join(_db.DirPartyTable, worker => new { Partition = worker.worker.Partition, RecId = worker.worker.Person },
                                                                                                                       dirParty => new { dirParty.Partition, dirParty.RecId }, (worker, dirParty) => new { worker, dirParty });

            query = query.Where(p => p.worker.casetable.vend.caseTable.caseTable.Partition == _partition
                                    && _dataAreaId.Contains(p.worker.casetable.vend.caseTable.caseTable.DataAreaId)
                                    && p.worker.casetable.vend.caseTable.caseTable.VendAccount == vendAccount);

            var results = await query.Select(view => new AMCaseTableView
            {
                Id = view.worker.casetable.vend.caseTable.caseTable.RecId,
                Particao = view.worker.casetable.vend.caseTable.caseTable.Partition,
                Empresa = view.worker.casetable.vend.caseTable.caseTable.DataAreaId,
                NumeroOcorrencia = view.worker.casetable.vend.caseTable.caseTable.CaseId,
                Descricao = view.worker.casetable.vend.caseTable.caseTable.Description,
                GrupoOcorrencia = view.worker.casetable.vend.caseTable.caseTable.GroupId,
                NumeroDispositivo = view.worker.casetable.vend.caseTable.caseTable.DeviceId,
                NomeDispositivo = view.worker.casetable.vend.caseTable.device.DeviceName,
                PlacaDispositivo = view.worker.casetable.vend.caseTable.device.RegistrationNumber,
                ContaCliente = view.worker.casetable.vend.caseTable.caseTable.CustAccount,
                ContaFornecedor = view.worker.casetable.vend.caseTable.caseTable.VendAccount,
                CNPJCPFFornecedor = view.worker.casetable.vend.vend.CNPJCPFNum_BR,
                NomeFornecedor = view.worker.casetable.dirParty.Name,
                NumeroEquipe = view.worker.worker.PersonnelNumber,
                Responsavel = view.dirParty.Name
            }
            ).ToListAsync();

            return results;
        }

        public async Task<IEnumerable<SalesLineView>> GetItems(string caseId)
        {
            var query = _db.SalesLine_OV.Join(_db.SalesLine, sLine_OV => new { Partition = sLine_OV.Partition, DataAreaId = sLine_OV.DataAreaId, RecId = sLine_OV.SalesLine },
                                                             sLine => new { sLine.Partition, sLine.DataAreaId, sLine.RecId }, (sLine_OV, sLine) => new { sLine_OV, sLine })
                                            .Join(_db.InventTable, sLine => new { sLine.sLine.Partition, sLine.sLine.DataAreaId, sLine.sLine.ItemId },
                                                                   invent => new { invent.Partition, invent.DataAreaId, invent.ItemId }, (sLine, invent) => new { sLine, invent })
                                                .Join(_db.EcoResProductTranslation, invent => new { invent.invent.Partition, invent.invent.Product },
                                                                                    productTrans => new { productTrans.Partition, productTrans.Product }, (invent, productTrans) => new { invent, productTrans });

            query = query.Where(p => p.invent.sLine.sLine_OV.Partition == _partition && _dataAreaId.Contains(p.invent.sLine.sLine_OV.DataAreaId) && p.invent.sLine.sLine_OV.AMCaseId == caseId && p.productTrans.LanguageId == "pt-br");

            var results = await query.Select(view => new SalesLineView
            {
                Id = view.invent.sLine.sLine.RecId,
                Particao = view.invent.sLine.sLine.Partition,
                Empresa = view.invent.sLine.sLine.DataAreaId,
                NumeroOcorrencia = view.invent.sLine.sLine_OV.AMCaseId,
                NumeroItem = view.invent.sLine.sLine.ItemId,
                NomeProduto = view.productTrans.Name,
                Quantidade = view.invent.sLine.sLine.SalesQty,
                Unidade = view.invent.sLine.sLine.SalesUnit,
                PrecoUnitario = view.invent.sLine.sLine.SalesPrice,
                Desconto = view.invent.sLine.sLine.LineDisc,
                PercentualDesconto = view.invent.sLine.sLine.LinePercent,
                ValorLiquido = view.invent.sLine.sLine.LineAmount,
                PercentualReembolso = view.invent.sLine.sLine_OV.RefundPercent,
                ValorReembolso = view.invent.sLine.sLine_OV.RefundPercent
            }
            ).ToListAsync();

            return results;
        }

    }
}
