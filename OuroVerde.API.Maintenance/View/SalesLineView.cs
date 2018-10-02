using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OuroVerde.API.Maintenance.View
{
    public class SalesLineView
    {
        public Int64 Id { get; set; }
        public Int64 Particao { get; set; }
        public string Empresa { get; set; }
        public string NumeroOcorrencia { get; set; }
        public string NumeroItem { get; set; }
        public decimal Quantidade { get; set; }
        public string Unidade { get; set; }
        public decimal PrecoUnitario { get; set; }
        public decimal Desconto { get; set; }
        public decimal PercentualDesconto { get; set; }
        public decimal ValorLiquido { get; set; }
        public decimal ValorReembolso { get; set; }
        public decimal PercentualReembolso { get; set; }
        public string NomeProduto { get; set; }
        public string Nome { get; set; }
    }
}
