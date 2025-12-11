using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Dominio.Entidade.Grupo;
using Dominio.Entidade.Solo;
using Dominio.Entidade.Usuario;

namespace Dominio.Entidade.Cacada
{
    public class Hunt : EntidadeBase
    {
        public string? Nome { get; set; }
        public string? Cidade { get; set; }

        // Relacionamento com o usuário dono da Hunt
        public int UsuarioSistameGuid { get; set; }
        public UsuarioSistema? UsuarioSistema { get; set; }

        // Relacionamentos com sessões
        [JsonIgnore]
        public ICollection<GrupoSessao> GrupoSessao { get; set; } = new List<GrupoSessao>();
        public ICollection<SoloSessao> SoloSessao { get; set; } = new List<SoloSessao>();
    }
}
