using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade.Sessao;
using Dominio.Entidade.Utilitarios.Membro;

namespace Dominio.Entidade.Grupo
{
    public class GrupoSessaoDto : SessaoBaseDto
    {
        public List<MembroDto>? Membros { get; set; }
    }
}
