using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OuroVerde.API.Maintenance.View;

namespace OuroVerde.API.Maintenance.Queries
{
    public interface IAMCaseQuery
    {
        Task<IEnumerable<AMCaseTableView>> Get(string vendAccount);
        Task<IEnumerable<AMCaseTableView>> GetStored(string vendAccount);
        Task<IEnumerable<SalesLineView>> GetItems(string caseId);
    }
}
