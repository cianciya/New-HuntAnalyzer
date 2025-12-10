using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade.Sessao
{
    public class SessaoHistoricoViewModel
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime SessionEnd { get; set; }
        public string? LootType { get; set; }
        public int Loot { get; set; }
        public int Supplies { get; set; }
        public int Balance { get; set; }
    }
}
