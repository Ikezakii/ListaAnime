using ListaAnime.Data;
using ListaAnime.Models;
using ListaAnime.Repositorio;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ListaAnime.Controllers
{
    public class AnimeController : Controller
    {

        private readonly IAnimeRepositorio _animerepositorio;
        private readonly BancoContext _context;

        public AnimeController(IAnimeRepositorio animeRepositorio, BancoContext context) 
        { 
            _animerepositorio = animeRepositorio;
            _context = context;
        }


        public IActionResult Index()
        {
            List<AnimeModel> animes =  _animerepositorio.BuscarTodos();    
            return View(animes);
        }

        public IActionResult Criar()
        {
            
            return View();
        }

        public IActionResult Editar(int id)
        {
            AnimeModel anime = _animerepositorio.ListarporId(id);
            return View(anime);
        }

        public IActionResult Apagar(int id) 
        {
            AnimeModel anime = _animerepositorio.ListarporId(id);
            return View(anime);
        }
        public IActionResult Edicao()
        {
            List<AnimeModel> animes = _animerepositorio.BuscarTodos();
            return View(animes);
        }

        public IActionResult ConfirmarAPG(int id)
        {
            try
            {
                bool apagado = _animerepositorio.Apagar(id);
                if (apagado)
                {
                    TempData["MensagemSucesso"] = "Anime apagado com sucesso";
                    
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possivel apagar o anime";
                }
                return RedirectToAction("Edicao");
            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = "Não foi possivel apagar o anime";
                return RedirectToAction("Edicao");
            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Criar(AnimeModel anime)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _animerepositorio.Adicionar(anime);
                    TempData["MensagemSucesso"] = "Anime adicionado com sucesso";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possível adicionar, confira as informações";
                    return View(anime);
                }

            }
            catch (System.Exception erro)
            {
                TempData["MensagemErro"] = "Não foi possível adicionar o anime";
                return RedirectToAction("Index");
            }
        }

        [HttpPost]
        public IActionResult Editar(AnimeModel anime)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _animerepositorio.Atualizar(anime);
                    TempData["MensagemSucesso"] = "Anime alterado com sucesso";
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["MensagemErro"] = "Não foi possivel realizar a alteração, confira as informações";
                    return View(anime);
                }
            }
            catch(System.Exception erro)
            {
                TempData["MensagemErro"] = "Não foi possivel alterar o anime";
                return RedirectToAction("Index");
            }
            
        }



    }
}
