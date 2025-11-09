using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TrabalhoApi.Data;
using TrabalhoApi.Dto.Autor;
using TrabalhoApi.Dto.Livro;
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

    public async Task<ResponseModel<Livro>> AtualizarLivro(int idLivro, LivroEdicaoDto livroEdicaoDto)
    {
        ResponseModel<Livro> resposta = new ResponseModel<Livro>();
        try
        {
            var livro = await _context.Livros.FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);
            var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == livroEdicaoDto.AutorId);

            //Debug.WriteLine(autor);

            // validando se o autor existe
            if (livro == null)
            {
                resposta.Mensagem = "livro não encontrado";
                resposta.Status = false;
                return resposta;
            }

            if(autor == null)
            {
                resposta.Mensagem = "autor não encontrado";
                resposta.Status = false;
                return resposta;
            }
                
            //Debug.WriteLine(livroEdicaoDto.AutorId);

            // atualizando os dados do autor
            livro.Titulo = livroEdicaoDto.Titulo ?? livro.Titulo;
            livro.Texto = livroEdicaoDto.Texto ?? livro.Texto;
            livro.Data = livroEdicaoDto.Data ?? livro.Data ;
            livro.AutorId = livroEdicaoDto.AutorId ?? livro.AutorId ;

            // salvando as alterações no banco de dados
            _context.Livros.Update(livro);
            await _context.SaveChangesAsync();

            // criando a resposta de sucesso
            resposta.Dados = livro;
            resposta.Mensagem = "livro atualizado com sucesso";
            return resposta;

        }
        catch (Exception ex)
        {
            resposta.Mensagem = ex.Message;
            resposta.Status = false;
            return resposta;
        }
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

    public async Task<ResponseModel<Livro>> DeletarLivro(int idLivro)
    {
        ResponseModel<Livro> resposta = new ResponseModel<Livro>();

        try
        {
            var livro = _context.Livros.FirstOrDefault(a => a.Id == idLivro);

            if (livro == null)
            {
                resposta.Mensagem = "livro não encontrado";
                return resposta;
            }

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();

            resposta.Dados = livro;
            resposta.Mensagem = "livro deletado com sucesso";
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
