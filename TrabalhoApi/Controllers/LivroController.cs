using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabalhoApi.Dto.Autor;
using TrabalhoApi.Dto.Noticias;
using TrabalhoApi.Model;
using TrabalhoApi.Models;
using TrabalhoApi.Services.Autor;
using TrabalhoApi.Services.Noticias;

namespace TrabalhoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        public readonly ILivroInterface _livroInterfacee;
        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterfacee = livroInterface;
        }


        [HttpGet]
        public async Task<ActionResult<ResponseModel<List<Livro>>>> ListarNoticias()
        {
            var noticias = await _livroInterfacee.ListarLivro();
            return Ok(noticias);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<List<Livro>>>> CriarNoticias(LivroCriacaoDto noticiasCriacaoDto)
        {
            var autores = await _livroInterfacee.CriarLivro(noticiasCriacaoDto);
            return Ok(autores);
        }
    }
}
