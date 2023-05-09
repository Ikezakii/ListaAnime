using ListaAnime.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaAnime.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {

        }
        public DbSet<AnimeModel> Animes { get; set; }


    }
}
