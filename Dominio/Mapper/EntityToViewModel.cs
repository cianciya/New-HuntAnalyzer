using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Dominio.Entidade.Grupo;
using Dominio.Entidade.Party;
using Dominio.Entidade.Solo;
using Dominio.Entidade.Usuario;
using Dominio.Entidade.Usuario.UsuarioViewModel;

namespace Dominio.Mapper
{
    public class EntityToViewModel : Profile
    {
        public EntityToViewModel()
        {
            // User
            CreateMap<UsuarioSistema, RegistroUsuarioSistemaViewModel>();
            CreateMap<UsuarioSistema, LoginUsuarioSistemaViewModel>()
                .ForMember(dest => dest.Password, opt => opt.MapFrom(src => src.PasswordHash));

            // Party Session
            CreateMap<GrupoMembros, GrupoMembrosViewModel>();

            // PartySession -> PartySessionViewModel
            CreateMap<GrupoSessao, GrupoSessaoViewModel>()
                .ForMember(d => d.Duration, opt => opt.Ignore()) // ignora no AutoMapper
                .ForMember(d => d.Members, opt => opt.MapFrom(s => s.Membros));

            // PartySession -> PartySessionWithCalcViewModel
            CreateMap<GrupoSessao, GrupoSessaoCalculoViewModel>()
                .ForMember(d => d.Duration, opt => opt.Ignore()) // ignora também aqui
                .ForMember(d => d.Members, opt => opt.MapFrom(s => s.Membros))
                .ForMember(d => d.TotalBalance, opt => opt.Ignore())
                .ForMember(d => d.PeopleCount, opt => opt.Ignore())
                .ForMember(d => d.BalancePerPerson, opt => opt.Ignore())
                .ForMember(d => d.Transferir, opt => opt.Ignore())
                .ForMember(d => d.DanoSplit, opt => opt.Ignore())
                .ForMember(d => d.Suggestions, opt => opt.Ignore());

            // Inverso Party
            CreateMap<GrupoSessaoViewModel, GrupoSessao>()
                .ForMember(dest => dest.Membros, opt => opt.MapFrom(src => src.Members));
            CreateMap<GrupoMembrosViewModel, GrupoMembros>();

            // Solo Session
            CreateMap<SoloSessao, SoloSessaoViewModel>().ReverseMap();
        }
    }
}
