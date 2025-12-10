using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade.Usuario;
using Dominio.Entidade.Usuario.UsuarioDto;

namespace Dominio.Entidade.Sessao
{
    public class SessaoBase : EntidadeBase
    {
        public string? Name { get; set; }
        public DateTime SessionStart { get; set; }
        public DateTime SessionEnd { get; set; }
        public string? LootType { get; set; }
        public int Loot { get; set; }
        public int Supplies { get; set; }
        public int Balance { get; set; }

        public int HuntId { get; set; }

        public int UsuarioSistemaGuid { get; set; }
        public UsuarioSistema UsuarioSistema { get; set; }
    }
}
