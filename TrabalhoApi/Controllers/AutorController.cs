using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrabalhoApi.Dto.Autor;
using TrabalhoApi.Model;
using TrabalhoApi.Models;
using TrabalhoApi.Services.Autor;

namespace TrabalhoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        public readonly IAutorInterface _autorInterface;
        public AutorController(IAutorInterface autorInterface) 
        {
            _autorInterface = autorInterface;
        }


        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var autores = await _autorInterface.ListarAutores();
            return Ok(autores);
        }

        [HttpPost]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> CriarAutor(AutorCriacaoDto autorCriacaoDto)
        {
            var autores = await _autorInterface.CriarAutor(autorCriacaoDto);
            return Ok(autores);
        }
    }
}
