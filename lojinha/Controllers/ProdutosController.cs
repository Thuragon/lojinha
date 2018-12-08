using AutoMapper;
using lojinha.Core.Models;
using lojinha.Core.Services;
using lojinha.Core.ViewModels;
using lojinha.Infrastructure.Storage;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lojinha.Controllers
{
    [Authorize]
    public class ProdutosController : Controller
    {
        private readonly IProdutoServices _produtoServices;
        private readonly IMapper _mapper;
        public ProdutosController(IProdutoServices produtoService, IMapper mapper)
        {
            // _azureStorage = azureStorage;

            _produtoServices = produtoService;
            _mapper = mapper;

        }

        public IActionResult Create()
        {
            var produto = new Produto()
            {
                Id = 331283,
                Nome = "Goku ",
                Categoria = new Categoria
                {
                    Id = 623,
                    Nome = "Action Figures"
                },
                Preco = 58.98m,
                Descricao = "Action figure do GOKU",
                Fabricante = new Fabricante
                {
                    Id = 231,
                    Nome = "Bandai"
                },
                Tags = new[] { "brinquedos", "ActionsFigure", "Bandai" },
                ImagemPrincipalUrl = "https://http2.mlstatic.com/dragon-ball-z-super-saiyan-goku-pvc-action-figure-bandai-D_NQ_NP_973611-MLB20590049453_022016-F.jpg",
            };
            // TODO: ProdutoServico.Add(produto)

            // _azureStorage.AddProduto(produto);
            return Content("OK");
        }

        public async Task<IActionResult> List()
        {

            var produtos = await _produtoServices.ObterProdutos();
            var vm = _mapper.Map<List<ProdutoViewModel>>(produtos);

            return View(vm);
        }

        public async Task<IActionResult>Details (string id)
        {

            var produto = await _produtoServices.ObterProduto(id);
            return Json(produto);
        }
    }
}
