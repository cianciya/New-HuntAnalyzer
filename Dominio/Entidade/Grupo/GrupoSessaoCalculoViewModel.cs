using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade.Utilitarios.Dano;
using Dominio.Entidade.Utilitarios.Transferir;

namespace Dominio.Entidade.Grupo
{
    public class GrupoSessaoCalculoViewModel
    {
        // Dados da session
        public int Id { get; set; }
        public int HuntId { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime SessionEnd { get; set; }
        public string? LootType { get; set; }
        public int Loot { get; set; }
        public int Supplies { get; set; }
        public int Balance { get; set; }
        public string? Duration { get; set; }
        public List<GrupoMembrosViewModel>? Members { get; set; }
        public bool IsPaid { get; set; }

        // Dados calculados
        public int TotalBalance { get; set; }
        public int PeopleCount { get; set; }
        public int BalancePerPerson { get; set; }
        public List<TransferirViewModel>? Transferir { get; set; }
        public List<DanoSplitViewModel>? DanoSplit { get; set; }
        public List<string>? Suggestions { get; set; }
    }
}
