using AutoMapper;
using V8Net.IO.Application.ViewModel;
using V8Net.IO.Domain.NoticiasContext;

namespace V8Net.IO.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Noticia, NoticiaViewModel>();
        }
    }
}