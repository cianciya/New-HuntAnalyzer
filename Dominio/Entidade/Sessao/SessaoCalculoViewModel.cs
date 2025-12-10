using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade.Utilitarios.Jogador;

namespace Dominio.Entidade.Sessao
{
    public class SessaoCalculoViewModel
    {
        public int SessionId { get; set; }
        public string? Name { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime SessionEnd { get; set; }
        public string? LootType { get; set; }
        public int TotalLoot { get; set; }
        public int TotalSupplies { get; set; }
        public int TotalBalance { get; set; }
        public decimal AverageProfit { get; set; }
        public List<JogadorBalanceViewModel>? Jogador { get; set; }
    }
}
