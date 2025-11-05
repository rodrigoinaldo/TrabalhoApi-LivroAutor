namespace TrabalhoApi.Dto.Autor
{
    public class AutorCriacaoDto
    {
        public AutorCriacaoDto(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; set; } 
        public string Email { get; set; }
    }
}
