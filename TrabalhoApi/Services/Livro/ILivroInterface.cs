using TrabalhoApi.Dto.Autor;
using TrabalhoApi.Dto.Noticias;
using TrabalhoApi.Model;
using TrabalhoApi.Models;

namespace TrabalhoApi.Services.Noticias;

public interface ILivroInterface
{
    Task<ResponseModel<List<Livro>>> ListarLivro();
    Task<ResponseModel<Livro>> CriarLivro(LivroCriacaoDto livroCriacaoDto);
}
