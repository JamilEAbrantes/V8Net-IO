using AutoMapper;
using V8Net.IO.Application.ViewModel;
using V8Net.IO.Domain.NoticiasContext.Commands;

namespace V8Net.IO.Application.AutoMapper
{
    public  class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<NoticiaViewModel, RegistrarNoticiaCommand>()
               .ConstructUsing(c => new RegistrarNoticiaCommand(c.Titulo, c.Subtitulo, c.Descricao, c.Autor));

            CreateMap<NoticiaViewModel, AtualizarNoticiaCommand>()
               .ConstructUsing(c => new AtualizarNoticiaCommand(c.Id, c.Titulo, c.Subtitulo, c.Descricao, c.Autor));

            CreateMap<NoticiaViewModel, ExcluirNoticiaCommand>()
               .ConstructUsing(c => new ExcluirNoticiaCommand(c.Id));
        }
    }
}