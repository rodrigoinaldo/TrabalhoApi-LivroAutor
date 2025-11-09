using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TrabalhoApi.Data;
using TrabalhoApi.Dto.Autor;
using TrabalhoApi.Model;
using TrabalhoApi.Models;

namespace TrabalhoApi.Services.Autor
{
    // fazer a comunicaçãoi entre o service e a interface 
    public class AutorService : IAutorInterface
    {

        private readonly AppDbContext _context;
        public AutorService(AppDbContext context) 
        { 
            _context = context;
        }

        public async Task<ResponseModel<AutorModel>> AtualizarAutor(int idAutor, AutorEdicaoDto autorEdicaoDto)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();
            try
            {
                var autor = await _context.Autores.FirstOrDefaultAsync(autorBanco => autorBanco.Id == idAutor);

                // validando se o autor existe
                if (autor == null)
                {
                    resposta.Mensagem = "Autor não encontrado";
                    resposta.Status = false;
                    return resposta;
                }

                //Debug.WriteLine(autor);

                // atualizando os dados do autor
                autor.Name = autorEdicaoDto.Name ?? autor.Name;
                autor.Email = autorEdicaoDto.Email ?? autor.Email;

                // salvando as alterações no banco de dados
                _context.Autores.Update(autor);
                await _context.SaveChangesAsync();

                // criando a resposta de sucesso
                resposta.Dados = autor;
                resposta.Mensagem = "Autor atualizado com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {
                var autor = new AutorModel()
                {
                    Name = autorCriacaoDto.Name,
                    Email = autorCriacaoDto.Email,
                };

                _context.Add(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = autor;
                resposta.Mensagem = "Autor criado com sucesso";


                return resposta;
            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }
        }

        public async Task<ResponseModel<AutorModel>> DeletarAutor(int idAutor)
        {
            ResponseModel<AutorModel> resposta = new ResponseModel<AutorModel>();

            try
            {

                var autor = _context.Autores.FirstOrDefault(a => a.Id == idAutor);

                if (autor == null)
                {
                    resposta.Mensagem = "Autor não encontrado";
                    return resposta;
                }

                _context.Autores.Remove(autor);
                await _context.SaveChangesAsync();

                resposta.Dados = autor;
                resposta.Mensagem = "Autor deletado com sucesso";
                return resposta;

            }
            catch (Exception ex)
            {
                resposta.Mensagem = ex.Message;
                resposta.Status = false;
                return resposta;
            }

        }

        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> resposta = new ResponseModel<List<AutorModel>>();

            try
            {

                var autores = await _context.Autores.ToListAsync();

                resposta.Dados = autores;
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
}
