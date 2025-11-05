using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
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
