using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovimentosManuais.ApplicationCore.Entity;
using MovimentosManuais.UI.Models;
using System.Net.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using Microsoft.Net.Http.Headers;
using System.Text;

namespace MovimentosManuais.UI.Controllers
{
    public class HomeController : Controller
    {
        private List<Produto> _listProduto;
        private List<Produto_Cosif> _listProdutoCosif;
        private SelectList _selectedItemProdutos;
<<<<<<< HEAD
        private List<Produto_Cosif> _selectedItemCosif;
=======
        private SelectList _selectedItemCosif;
>>>>>>> fbdacfb834b1711aa4135de4f176d0497be77dad
        private HttpClient _httpClient;
        private List<Movimento_Manual> _listGridManual;
        public HomeController(IHttpClientFactory httpClientFactory)
        {
            _httpClient = httpClientFactory.CreateClient(InfraStruture.Extension.Extensions.NameHppClient);

            CarregarListaProdutos();
            CarregarListaProdutosCosif();
            CarregarListaGrid();
            ViewData["PRODUTO"] = _selectedItemProdutos;
            ViewData["PRODUTO_COSIF"] = _selectedItemCosif;
            ViewBag.ListaGrid = _listGridManual;
        }

        private void CarregarListaGrid()
        {
            var responseProdutosCosif = _httpClient.GetAsync("MovimentosManuais").GetAwaiter().GetResult();
            if (responseProdutosCosif.IsSuccessStatusCode)
            {
                _listGridManual = JsonConvert.DeserializeObject<List<Movimento_Manual>>(
                        responseProdutosCosif.Content
                            .ReadAsStringAsync()
                                .GetAwaiter().GetResult());

            }
        }

        private void CarregarListaProdutosCosif()
        {
            var responseProdutosCosif = _httpClient.GetAsync("ProdutosCosif").GetAwaiter().GetResult();
            if (responseProdutosCosif.IsSuccessStatusCode)
            {
<<<<<<< HEAD
                _selectedItemCosif = JsonConvert.DeserializeObject<List<Produto_Cosif>>(
                                            responseProdutosCosif.Content.ReadAsStringAsync()
                                                    .GetAwaiter()
                                                        .GetResult());
=======
                _selectedItemCosif = new SelectList(
                                    JsonConvert.DeserializeObject<List<Produto_Cosif>>(
                                            responseProdutosCosif.Content.ReadAsStringAsync()
                                                    .GetAwaiter()
                                                        .GetResult()), "COD_COSIF", "COD_PRODUTO");
>>>>>>> fbdacfb834b1711aa4135de4f176d0497be77dad

            }
        }

        private void CarregarListaProdutos()
        {
            var responseProdutos = _httpClient.GetAsync("Produtos").GetAwaiter().GetResult();


            if (responseProdutos.IsSuccessStatusCode)
            {
                _selectedItemProdutos = new SelectList(
                                    JsonConvert.DeserializeObject<List<Produto>>(
                                            responseProdutos.Content.ReadAsStringAsync()
                                                    .GetAwaiter()
                                                        .GetResult()), "COD_PRODUTO", "DES_PRODUTO");

            }
        }

        public IActionResult Index()
        {
            
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult MovimentosManuais() 
        {
            ViewData["ReadOnly"] = true;
            ViewData["PRODUTO"] = _selectedItemProdutos;
            ViewData["PRODUTO_COSIF"] = _selectedItemCosif;
            CarregarListaGrid();
            ViewBag.ListaGrid = _listGridManual;
<<<<<<< HEAD
            return View(new Movimento_Manual());
=======
            return View();
>>>>>>> fbdacfb834b1711aa4135de4f176d0497be77dad
        }
        public IActionResult Novo() 
        {
            ViewData["ReadOnly"] = false;
            ViewData["PRODUTO"] = _selectedItemProdutos;
            ViewData["PRODUTO_COSIF"] = _selectedItemCosif;
            CarregarListaGrid();
            ViewBag.ListaGrid = _listGridManual;

<<<<<<< HEAD
            return View("MovimentosManuais", new Movimento_Manual());
=======
            return View("MovimentosManuais");
>>>>>>> fbdacfb834b1711aa4135de4f176d0497be77dad
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> IncluirDados(Movimento_Manual movimentoManul) 
        {
            movimentoManul.DAT_MOVIMENTO = DateTime.Now;

            if (ModelState.IsValid)
            {
                StringContent content = new StringContent(JsonConvert.SerializeObject(movimentoManul),Encoding.UTF8, "application/json");
                _httpClient.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
                var response = await _httpClient.PostAsync("MovimentosManuais", content);
                CarregarListaGrid();
                if(response.IsSuccessStatusCode)
                    return Redirect("MovimentosManuais");
                else
                    return View("MovimentosManuais", movimentoManul);

            }
            else
            {
                ViewData["ReadOnly"] = false;
                ViewData["COD_PRODUTO"] = _selectedItemProdutos;
                ViewData["PRODUTO_COSIF"] = _selectedItemCosif;
                return View("MovimentosManuais",movimentoManul);
            }
        }

        public IActionResult Limpar()
        {
            ViewData["ReadOnly"] = false;
            ViewData["COD_PRODUTO"] = _selectedItemProdutos;
            ViewData["PRODUTO_COSIF"] = _selectedItemCosif;
            ViewBag.ListaGrid = _listGridManual;
            return View("MovimentosManuais",new Movimento_Manual());
        } 

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        
        public IActionResult Get(string IdProduto)
        {
            return Ok(_selectedItemCosif.Where(x=>x.COD_PRODUTO==IdProduto));
        }
    }
}
