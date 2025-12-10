using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade.Grupo
{
    public class GrupoSessaoViewModel
    {
        public int Id { get; set; }
        public int HuntId { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime SessionEnd { get; set; }
        public string? LootType { get; set; }
        public int Loot { get; set; }
        public int Supplies { get; set; }
        public int Balance { get; set; }
        public string Duration { get; set; } = string.Empty;

        public List<GrupoMembrosViewModel> Members { get; set; } = new();
    }
}
