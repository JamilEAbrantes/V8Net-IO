namespace V8Net.IO.Domain.NoticiasContext.Commands
{
    public class RegistrarNoticiaCommand : BaseNoticiaCommand
    {
        public RegistrarNoticiaCommand(
            string titulo,
            string subtitulo,
            string descricao,
            string autor)
        {
            Titulo = titulo;
            Subtitulo = subtitulo;
            Descricao = descricao;
            Autor = autor;
        }
    }
}
