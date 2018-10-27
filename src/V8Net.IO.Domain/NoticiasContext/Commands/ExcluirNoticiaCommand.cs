using System;

namespace V8Net.IO.Domain.NoticiasContext.Commands
{
    public class ExcluirNoticiaCommand : BaseNoticiaCommand
    {
        public ExcluirNoticiaCommand(Guid id)
        {
            Id = id;
            AggregateId = Id;
        }
    }
}
