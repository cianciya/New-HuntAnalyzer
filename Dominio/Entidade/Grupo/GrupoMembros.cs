using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade.Grupo;

namespace Dominio.Entidade.Party
{
    public class GrupoMembros : EntidadeBase
    {
        public string? Name { get; set; }
        public bool IsLeader { get; set; }
        public int Loot { get; set; }
        public int Supplies { get; set; }
        public int Balance { get; set; }
        public int Damage { get; set; }
        public int Healing { get; set; }

        //Vinculos
        public int GrupoSessaoGuid { get; set; }
        public GrupoSessao? GrupoSessao { get; set; }
    }
}
