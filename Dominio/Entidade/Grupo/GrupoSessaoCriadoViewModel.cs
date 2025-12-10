using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade.Utilitarios.Dano;
using Dominio.Entidade.Utilitarios.Transferir;

namespace Dominio.Entidade.Grupo
{
    public class GrupoSessaoCriadoViewModel
    {
        public GrupoSessaoViewModel Session { get; set; } = new();
        public int TotalBalance { get; set; }
        public int PeopleCount { get; set; }
        public int BalancePerPerson { get; set; }
        public List<TransferirViewModel> Transferir { get; set; } = new();
        public List<DanoSplitViewModel> DanoSplit { get; set; } = new();

        // textos prontos pra UI
        public List<string> Suggestions { get; set; } = new();
    }
}
