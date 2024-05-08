using csharpCamadas.API.DAL;
using csharpCamadas.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace csharpCamadas.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TipoCombustivelController : ControllerBase
    {
        protected readonly csharpCamadasContext _context;

        public TipoCombustivelController(csharpCamadasContext context)
        {
            _context = context;
        }

        [HttpGet("/TipoCombustivel")]
        public async Task<IActionResult> PegarTodosTipoCombustivel()
        {
            try
            {
                var dados = await _context.Set<TiposDeCombustivel>().ToListAsync();
                var dadosPosto = await _context.Set<Posto>().ToListAsync();
                //List<TiposDeCombustivel> lista = new List<TiposDeCombustivel>();

                //foreach (var item in dados)
                //{
                //    TiposDeCombustivel Model = new TiposDeCombustivel
                //    {
                //        TipoId = item.TipoId,
                //        TipoNome = item.TipoNome,
                //        TipoEndereco = item.TipoEndereco,
                //        TipoValor = item.TipoValor,
                //        //PostoList = dadosPosto.Where(x => x.PosId == item.PosId).ToList(),
                //    };
                //    lista.Add(Model);
                //}

                return Ok(dados);
            }
            catch (Exception ex)
            {
                return BadRequest("erro: " + ex);
            }
        }
    }
}
