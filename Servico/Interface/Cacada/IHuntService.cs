using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Entidade.Cacada;

namespace Servico.Interface.Cacada
{
    public interface IHuntService
    {
        Task<Hunt> CreateAsync(HuntDto dto, int usuarioLogado);
    }
}
