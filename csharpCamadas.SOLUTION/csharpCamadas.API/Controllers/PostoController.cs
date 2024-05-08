using csharpCamadas.API.DAL;
using csharpCamadas.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace csharpCamadas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostoController : ControllerBase
    {
        protected readonly csharpCamadasContext _context;

        public PostoController(csharpCamadasContext context)
        {
            _context = context;
        }

        [HttpGet("/Posto")]
        public async Task<IActionResult> PegarTodosOsPostos()
        {
            try
            {
                var dados = await _context.Set<TiposDeCombustivel>().ToListAsync();
                var dadosPosto = await _context.Set<Posto>().ToListAsync();
                List<Posto> lista = new List<Posto>();

                foreach (var item in dadosPosto)
                {
                    Posto Model = new Posto
                    {
                        PosId = item.PosId,
                        PosNome = item.PosNome,
                        PosCidade = item.PosCidade,
                        PosEndereco = item.PosEndereco,
                        TiposDeCombustivels = dados.Where(x => x.PosId == item.PosId).ToList(),
                    };
                    lista.Add(Model);
                }
                return Ok(lista);
            }
            catch (Exception ex)
            {
                return BadRequest("erro: " + ex);
            }
        }
    }
}
