using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovimentosManuais.ApplicationCore.Entity;
using MovimentosManuais.ApplicationCore.Interfaces.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MovimentosManuais.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MovimentosManuaisController : ControllerBase
    {
        private IMovimentosManuaisServices _movimentoManualService;
        public MovimentosManuaisController(IMovimentosManuaisServices movimentoManual)
        {
            _movimentoManualService = movimentoManual;
        }


        [HttpPost]
        public IActionResult IncluirMovimentosManuais([FromBody]Movimento_Manual movimentoManual) 
        {
            try
            {
                _movimentoManualService.Adicionar(movimentoManual);
                return Ok();
            }
            catch (System.Exception eX)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Não foi possível gravar os dados do movimento.");
            }
        }

        [HttpGet]
        public ActionResult<IList<Movimento_Manual>> Get()
        {
            return Ok(_movimentoManualService.ObterTodos());
        }

       
    }
}
