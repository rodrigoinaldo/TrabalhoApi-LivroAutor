using TrabalhoApi.Dto.Autor;
using TrabalhoApi.Model;
using TrabalhoApi.Models;

namespace TrabalhoApi.Services.Autor
{
    public interface IAutorInterface
    {
        // buscar todos
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> CriarAutor(AutorCriacaoDto autorCriacaoDto);
        Task<ResponseModel<AutorModel>> AtualizarAutor(int idAutor, AutorEdicaoDto autorEdicaoDto);
        Task<ResponseModel<AutorModel>> DeletarAutor(int idAutor);

    }
}