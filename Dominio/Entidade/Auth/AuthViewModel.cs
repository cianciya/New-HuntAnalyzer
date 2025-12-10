using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Entidade.Auth
{
    public class AuthViewModel
    {
        public bool Autenticado { get; set; }
        public string Token { get; set; }
        public string Message { get; set; }
    }
}
