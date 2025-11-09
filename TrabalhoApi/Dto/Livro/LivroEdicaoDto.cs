using TrabalhoApi.Model;

namespace TrabalhoApi.Dto.Livro
{
    public class LivroEdicaoDto
    {

        public string? Titulo { get; set; }
        public string? Texto { get; set; }
        public string? Data { get; set; }
        public int? AutorId { get; set; }
    }
}
