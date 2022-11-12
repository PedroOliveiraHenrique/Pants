using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NetPants.Models;
using NetPants.Repositories.Interfaces;
using NetPants.ViewModels;

namespace NetPants.Controllers
{
    public class CarrinhoCompraController : Controller
    {
        private readonly IRoupaRepository _roupaRepository;
        private readonly CarrinhoCompra _carrinhoCompra;

        public CarrinhoCompraController(IRoupaRepository roupaRepository, 
            CarrinhoCompra carrinhoCompra)
        {
            _roupaRepository = roupaRepository;
            _carrinhoCompra = carrinhoCompra;
        }

        public IActionResult Index()
        {
            var itens = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItems = itens;

            var carrinhoCompraVM = new CarrinhoCompraViewModel
            {
                CarrinhoCompra = _carrinhoCompra,
                CarrinhoCompraTotal = _carrinhoCompra.GetCarrinhoCompraTotal()
            };
            return View(carrinhoCompraVM);
        }

        [Authorize]
        public IActionResult AdicionarItemNoCarrinhoCompra(int roupaId)
        {
            var roupaSelecionada = _roupaRepository.Roupas.FirstOrDefault(p => p.RoupaId == roupaId);
            if(roupaSelecionada != null)
            {
                _carrinhoCompra.AdicionarAoCarrinho(roupaSelecionada);
            }
            return RedirectToAction("Index");
        }

        [Authorize]
        public IActionResult RemoverItemDoCarrinhoCompra(int roupaId)
        {
            var roupaSelecionada = _roupaRepository.Roupas.FirstOrDefault(p => p.RoupaId == roupaId);
            if (roupaSelecionada != null)
            {
                _carrinhoCompra.RemoverDoCarrinho(roupaSelecionada);
            }
            return RedirectToAction("Index");
        }
    }
}
