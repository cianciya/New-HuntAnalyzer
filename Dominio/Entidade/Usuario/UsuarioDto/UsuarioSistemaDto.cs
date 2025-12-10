using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade.Usuario.UsuarioDto
{
    public class UsuarioSistemaDto
    {
        public string? NomeUsuario { get; set; }
        public string? PasswordHash { get; set; }
        public string? CharacterName { get; set; }
    }
}
