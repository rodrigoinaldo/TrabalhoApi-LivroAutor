namespace TrabalhoApi.Dto.Autor
{
    public class AutorEdicaoDto
    {
        public AutorEdicaoDto(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string? Name { get; set; }
        public string? Email { get; set; }
    }
}
