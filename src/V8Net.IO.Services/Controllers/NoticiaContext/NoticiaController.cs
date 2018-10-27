using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using V8Net.IO.Application.Interfaces;
using V8Net.IO.Application.ViewModel;
using V8Net.IO.Domain.Core.Bus;
using V8Net.IO.Domain.Core.Notification;

namespace V8Net.IO.Services.Controllers.NoticiaContext
{
    public class NoticiaController : ApiController
    {
        private readonly INoticiaAppService _noticiaAppService;
        private readonly IMapper _mapper;

        public NoticiaController(
            INoticiaAppService noticiaAppService,
            IMapper mapper,
            IDomainNotificationHandler<DomainNotification> notifications,
            IBus bus) : base(notifications, bus)
        {
            _noticiaAppService = noticiaAppService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("v8net/nova-noticia")]
        public IActionResult Registrar([FromBody]NoticiaViewModel command)
        {
            _noticiaAppService.Registrar(command);
            return Response(command);
        }

        [HttpPut]
        [Route("v8net/atualizar-noticia")]
        public IActionResult Atualizar([FromBody]NoticiaViewModel command)
        {
            if (!ModelState.IsValid)
            {
                NotifyModelStateErrors();
                return Response(command);
            }

            _noticiaAppService.Atualizar(command);

            return Response(command);
        }

        [HttpDelete]
        [Route("v8net/excluir-noticia")]
        public IActionResult Remover([FromBody]NoticiaViewModel command)
        {
            _noticiaAppService.Remover(command.Id);
            return Response(command);
        }

        [HttpGet]
        [Route("v8net/noticias")]
        public IActionResult ObterTodos()
        {
            var result = _mapper.Map<IEnumerable<NoticiaViewModel>>(_noticiaAppService.ObterTodos());
            return Response(result);
        }

        [HttpGet]
        [Route("v8net/noticias-por-autor/{autor}")]
        public IActionResult ObterNoticiaPorAutor(string autor)
        {
            var result = _mapper.Map<IEnumerable<NoticiaViewModel>>(_noticiaAppService.ObterNoticiaPorAutor(autor));
            return Response(result);
        }
    }
}