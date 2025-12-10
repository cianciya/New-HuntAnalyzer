using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade.Usuario.UsuarioDto
{
    public class LoginUsuarioSistemaDto
    {
        public string? NomeUsuario { get; set; }
        public string? PasswordHash { get; set; }
    }
}
