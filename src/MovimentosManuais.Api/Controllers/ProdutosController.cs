using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovimentosManuais.ApplicationCore.Entity;
using MovimentosManuais.ApplicationCore.Interfaces.Services;
using System.Threading.Tasks;

namespace MovimentosManuais.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private IProdutoService _produtosService;
        public ProdutosController(IProdutoService produtos)
        {
            _produtosService = produtos;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_produtosService.ObterTodos());
        }
        
    }
}
