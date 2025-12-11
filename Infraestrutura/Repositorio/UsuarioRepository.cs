using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade.Usuario;
using Dominio.Interface.Usuario;
using Infraestrutura.Contexto;
using Microsoft.EntityFrameworkCore;

namespace Infraestrutura.Repositorio
{
    public class UsuarioRepository : RepositoryBase<UsuarioSistema, ClienteContexto>, IUsuarioRepository
    {
        public UsuarioRepository(ClienteContexto context) : base(context)
        {
        }

        public async Task<UsuarioSistema> GetByUserNameAsync(object nomeUsuario)
        {
            return await _context.UsuarioSistema.FirstOrDefaultAsync(f => f.NomeUsuario == nomeUsuario);
        }
    }
}
