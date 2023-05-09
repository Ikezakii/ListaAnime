using ListaAnime.Data;
using ListaAnime.Models;
using System.Xml.Linq;

namespace ListaAnime.Repositorio
{
    public class AnimeRepositorio : IAnimeRepositorio
    {

        private readonly BancoContext _bancocontext;

        public AnimeRepositorio(BancoContext bancocontext)
        {
            _bancocontext = bancocontext;
        }

        public AnimeModel Adicionar(AnimeModel anime)
        {
            _bancocontext.Animes.Add(anime);
            _bancocontext.SaveChanges();    
            return anime;
        }

        public bool Apagar(int id)
        {
            AnimeModel animeDB = ListarporId(id);

            if (animeDB == null) throw new Exception("Houve um erro na exclusão");

            _bancocontext.Animes.Remove(animeDB);
            _bancocontext.SaveChanges();
            return true;
        }

        public AnimeModel Atualizar(AnimeModel anime)
        {
            AnimeModel animeDB = ListarporId(anime.Id);

            if (animeDB == null) throw new Exception("Houve um erro na atualização");

                animeDB.Nome = anime.Nome;
                animeDB.Nota = anime.Nota;
                animeDB.Descricao = anime.Descricao;
                animeDB.Temporada = anime.Temporada;

            _bancocontext.Animes.Update(animeDB);
            _bancocontext.SaveChanges();
            return animeDB;

        }

        public List<AnimeModel> BuscarTodos()
        {
            return _bancocontext.Animes.ToList();

        }

        public AnimeModel ListarporId(int id)
        {
            return _bancocontext.Animes.FirstOrDefault(x => x.Id == id);
        }
    }
}
