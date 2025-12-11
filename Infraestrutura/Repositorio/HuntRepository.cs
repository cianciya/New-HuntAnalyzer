using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade.Cacada;
using Dominio.Entidade.Usuario;
using Dominio.Interface.Usuario;
using Infraestrutura.Contexto;

namespace Infraestrutura.Repositorio
{
    public class HuntRepository : RepositoryBase<Hunt, ClienteContexto>, IHuntRepository
    {
        public HuntRepository(ClienteContexto context) : base(context)
        {
        }
    }
}
