using csharpCamadas.API.DAL;
using csharpCamadas.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace csharpCamadas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MostoristaController : ControllerBase
    {
        private readonly csharpCamadasContext _context;

        public MostoristaController(csharpCamadasContext context)
        {
            _context = context;
        }

        [HttpGet("/Motorista")]
        public async Task<IActionResult> PegarTodosMotoristas()
        {
            try
            {
                var dados = await _context.Set<Motoristum>().ToListAsync();

                List<Motoristum> list = new List<Motoristum>();

                foreach (var item in dados)
                {
                    Motoristum Model = new Motoristum
                    {
                        MotId = item.MotId,
                        MotIdade = item.MotIdade,
                        MotNome = item.MotNome,
                        VeiId = item.VeiId,
                        Vei = await _context.Set<Veiculo>().FindAsync(item.VeiId)
                    };
                    list.Add(Model);
                }
                return Ok(list);
            }
            catch (Exception ex)
            {
                return BadRequest("error: " + ex);
            }
        }
    }
}
