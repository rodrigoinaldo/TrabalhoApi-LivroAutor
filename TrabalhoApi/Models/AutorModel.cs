using Garagem.Application.Entities;
using System.Text.Json.Serialization;

namespace TrabalhoApi.Model
{
    public class AutorModel : Entity
    {

        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;

        // para na hora que eu inserir ele não pedir as noticias que ele crioou 
        [JsonIgnore]
        public ICollection<Livro> Noticias { get; set; } = new List<Livro>();

    }
}
