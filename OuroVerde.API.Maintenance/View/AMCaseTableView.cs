using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OuroVerde.API.Maintenance.View
{
    public class AMCaseTableView
    {
        public Int64 Id { get; set; }
        public Int64 Particao { get; set; }
        public string Empresa { get; set; }
        public string NumeroOcorrencia { get; set; }
        public string Descricao { get; set; }
        public string GrupoOcorrencia { get; set; }
        public string NumeroDispositivo { get; set; }
        public string NomeDispositivo { get; set; }
        public string PlacaDispositivo { get; set; }
        public string ContaCliente { get; set; }
        public string ContaFornecedor { get; set; }
        public string CNPJCPFFornecedor { get; set; }
        public string NomeFornecedor { get; set; }
        public string Responsavel { get; set; }
        public string NumeroEquipe { get; set; }
    }
}
