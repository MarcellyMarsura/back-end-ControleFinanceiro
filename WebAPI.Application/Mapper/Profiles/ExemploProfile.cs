using AutoMapper;
using WebAPI.Application.ViewModel;
using WebAPI.Domain.Model;

namespace WebAPI.Application.Mapper.Profiles
{
    public class ExemploProfile : Profile
    {
        public ExemploProfile() 
        {
            CreateMap<Exemplo, ExemploViewModel>();
            CreateMap<ExemploViewModel, Exemplo>();
        }

    }
}
