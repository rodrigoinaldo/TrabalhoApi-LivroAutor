using Microsoft.EntityFrameworkCore;
using TrabalhoApi.Model;

namespace TrabalhoApi.Data
{

    // conecação entre o codigo e o banco de dados, para fazer o meio de campo
    public class AppDbContext : DbContext
    {

        // recebe´para fazer conexão com o banco de dadoso
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }
        
        // passando as model ara fazer criação no banco 
        public DbSet<AutorModel> Autores { get; set; }
        public DbSet<Livro> Livros { get; set; }
    }
}
