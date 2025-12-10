using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace Dominio.Mapper
{
    public class AutoMapperConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            return new MapperConfiguration(m =>
            {
                m.AddProfile(new EntityToViewModel());
                m.AddProfile(new DtoToEntityProfile());
            });

        }
    }
}
