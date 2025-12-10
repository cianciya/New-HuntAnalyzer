using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade.Party;
using Dominio.Entidade.Sessao;

namespace Dominio.Entidade.Grupo
{
    public class GrupoSessao : SessaoBase
    {
        public ICollection<GrupoMembros> Membros { get; set; }
        public int UsuarioSistemaGuid { get; set; }
        public TimeSpan SessionDuration { get; set; }
        public bool IsPaid { get; set; }
    }
}
