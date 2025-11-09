using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabalhoApi.Dto.Autor;
using TrabalhoApi.Dto.Livro;
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

        [HttpPut]
        public async Task<ResponseModel<Livro>> AtualizarLivro(int idLivro, LivroEdicaoDto livroEdicaoDto)
        {
            var livros = await _livroInterfacee.AtualizarLivro(idLivro, livroEdicaoDto);
            return livros;
        }

        [HttpDelete]
        public async Task<ResponseModel<Livro>> DeletarLivro(int idLivro)
        {
            var livros = await _livroInterfacee.DeletarLivro(idLivro);
            return livros;
        }
    }
}
