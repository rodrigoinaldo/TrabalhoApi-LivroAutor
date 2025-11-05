using Microsoft.EntityFrameworkCore;
using TrabalhoApi.Data;
using TrabalhoApi.Dto.Noticias;
using TrabalhoApi.Model;
using TrabalhoApi.Models;

namespace TrabalhoApi.Services.Noticias;

public class LivroService : ILivroInterface
{
    private readonly AppDbContext _context;
    public LivroService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<ResponseModel<Livro>> CriarLivro(LivroCriacaoDto livroCriacaoDto)
    {
        ResponseModel<Livro> resposta = new ResponseModel<Livro>();

        try
        {
            var livro = new Livro()
            {
                Titulo = livroCriacaoDto.Titulo,
                Texto = livroCriacaoDto.Texto,
                Data = livroCriacaoDto.Data,
                AutorId = livroCriacaoDto.AutorId
            };

            _context.Add(livro);
            await _context.SaveChangesAsync();

            var livroComAutor = await _context.Livros.Include(n => n.Autor).FirstOrDefaultAsync(n => n.Id == livro.Id);

            resposta.Dados = livroComAutor;


            return resposta;
        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }

    public async Task<ResponseModel<List<Livro>>> ListarLivro()
    {
        ResponseModel<List<Livro>> resposta = new ResponseModel<List<Livro>>();

        try
        {

            var livros = await _context.Livros.Include(n => n.Autor).ToListAsync();


            resposta.Dados = livros;
            resposta.Mensagem = "Deu bom";

            return resposta;

        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
    }
}
