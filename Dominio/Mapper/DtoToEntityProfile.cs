using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.Entidade.Cacada;
using Dominio.Entidade.Grupo;
using Dominio.Entidade.Party;
using Dominio.Entidade.Sessao;
using Dominio.Entidade.Solo;
using Dominio.Entidade.Usuario;
using Dominio.Entidade.Usuario.UsuarioDto;
using Dominio.Entidade.Utilitarios.Membro;

namespace Dominio.Mapper
{
    public class DtoToEntityProfile : Profile
    {
        public DtoToEntityProfile()
        {
            // User
            CreateMap<UsuarioSistemaDto, UsuarioSistema>().ReverseMap();

            // Hunt
            CreateMap<HuntDto, Hunt>().ReverseMap();

            // Party Session
            CreateMap<GrupoSessaoDto, GrupoSessao>()
                .ForMember(dest => dest.Membros, opt => opt.MapFrom(src => src.Membros))
                .ReverseMap();

            CreateMap<MembroDto, GrupoMembros>().ReverseMap();

            // Solo Session
            CreateMap<SoloSessaoDto, SoloSessao>().ReverseMap();

            // Session base (somente se ENTIDADES herdarem de SessionBase)
            // Atualmente PartySession herda, mas SoloSession não.
            CreateMap<SessaoBaseDto, SessaoBase>()
                .Include<GrupoSessaoDto, GrupoSessao>()
                .Include<SoloSessaoDto, SoloSessao>()
                .ReverseMap();
        }
    }
}

