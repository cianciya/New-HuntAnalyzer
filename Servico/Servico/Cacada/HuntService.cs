using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.Entidade.Cacada;
using Dominio.Interface.Cacada;
using Servico.Interface.Cacada;

namespace Servico.Servico.Cacada
{
    public class HuntService : IHuntService
    {
        private readonly IHuntRepository _repository;
        private readonly IMapper _mapper;

        public HuntService(IHuntRepository repository)
        {
            _repository = repository;
        }

        public async Task<Hunt> CreateAsync(HuntDto dto, int usuarioLogado)
        {
            Hunt hunt = _mapper.Map<Hunt>(dto);
            hunt.UsuarioSistameGuid = usuarioLogado;

            await _repository.CreatAsync(hunt); 
            return hunt;
        }
    }
}
