using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MovimentosManuais.ApplicationCore.Entity;
using MovimentosManuais.ApplicationCore.Interfaces.Services;
using System.Threading.Tasks;

namespace MovimentosManuais.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosCosifController : ControllerBase
    {
        private IProdutosCosifsServices _produtosCosifService;
        public ProdutosCosifController(IProdutosCosifsServices produtosCosif)
        {
            _produtosCosifService = produtosCosif;
        }

        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_produtosCosifService.ObterTodos());
        }
        
    }
}
