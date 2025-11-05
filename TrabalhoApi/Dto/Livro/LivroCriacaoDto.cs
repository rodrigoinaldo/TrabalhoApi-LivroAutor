namespace TrabalhoApi.Dto.Noticias
{
    public class LivroCriacaoDto
    {
        public LivroCriacaoDto(string titulo, string texto, string data, int autorId)
        {
            Titulo = titulo;
            Texto = texto;
            Data = data;
            AutorId = autorId;
        }

        public string Titulo { get; set; }
        public string Texto { get; set; }
        public string Data { get; set; }
        public int AutorId { get; set; }
    }
}
