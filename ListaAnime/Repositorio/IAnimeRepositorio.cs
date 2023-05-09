using ListaAnime.Models;

namespace ListaAnime.Repositorio
{
    public interface IAnimeRepositorio
    {
        AnimeModel Adicionar(AnimeModel anime);

        List<AnimeModel> BuscarTodos();

        AnimeModel ListarporId(int id);

        AnimeModel Atualizar(AnimeModel anime);

        bool Apagar(int id);
    }
}
