using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade.Grupo
{
    public class GrupoMembrosViewModel
    {
        public string Name { get; set; } = string.Empty;
        public bool IsLeader { get; set; }
        public int Loot { get; set; }
        public int Supplies { get; set; }
        public int Balance { get; set; }
        public int Damage { get; set; }
        public int Healing { get; set; }
    }
}
