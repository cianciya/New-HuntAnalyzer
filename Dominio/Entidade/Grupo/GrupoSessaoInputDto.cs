using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade.Grupo
{
    public class GrupoSessaoInputDto
    {
        public int HuntId { get; set; }
        public string Clipboard { get; set; } = string.Empty;
    }
}
