using Garagem.Application.Entities;

namespace TrabalhoApi.Model
{
    public class Livro : Entity
    {
        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Data { get; set; }
        public int AutorId { get; set; } 
        public AutorModel Autor { get; set; }

        public Livro() { } 


    }
}
