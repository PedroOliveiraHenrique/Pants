using Microsoft.AspNetCore.Mvc;
using NetPants.Models;
using NetPants.Repositories.Interfaces;
using NetPants.ViewModels;

namespace NetPants.Controllers
{
    public class RoupaController : Controller
    {
        private readonly IRoupaRepository _roupaRepository;

        public RoupaController(IRoupaRepository roupaRpository)
        {
            _roupaRepository = roupaRpository;
        }

        public IActionResult List(string categoria)
        {
            IEnumerable<Roupa> roupas;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(categoria))
            {
                roupas = _roupaRepository.Roupas.OrderBy(l => l.RoupaId);
                categoriaAtual = "Todas as Roupas";
            }
            else
            {
                //if(string.Equals("Roupas", categoria, StringComparison.OrdinalIgnoreCase))
                //{
                //    roupas = _roupaRepository.Roupas
                //        .Where(l => l.Categoria.CategoriaNome.Equals("Roupas"))
                //        .OrderBy(l => l.Nome);
                //}
                //else
                //{
                //    roupas = _roupaRepository.Roupas
                //       .Where(l => l.Categoria.CategoriaNome.Equals("Calçados"))
                //       .OrderBy(l => l.Nome);
                //}

                roupas = _roupaRepository.Roupas
                    .Where(l => l.Categoria.CategoriaNome.Equals(categoria))
                    .OrderBy(c => c.Nome);

                categoriaAtual = categoria;
            }
            var roupasListViewModel = new RoupaListViewModel
            {
                Roupas = roupas,
                CategoriaAtual = categoriaAtual
            };

            return View(roupasListViewModel);
        }

        public IActionResult Details(int roupaId)
        {
            var roupa = _roupaRepository.Roupas.FirstOrDefault(l => l.RoupaId == roupaId);
            return View(roupa);
        }

        public ViewResult Search(string searchString)
        {
            IEnumerable<Roupa> roupas;
            string categoriaAtual = string.Empty;

            if (string.IsNullOrEmpty(searchString))
            {
                roupas = _roupaRepository.Roupas.OrderBy(p => p.RoupaId);
                categoriaAtual = "Todas as Roupas";
            }
            else
            {
                roupas = _roupaRepository.Roupas
                    .Where(p => p.Nome.ToLower().Contains(searchString.ToLower()));

                if (roupas.Any())
                    categoriaAtual = "Roupas";
                else
                    categoriaAtual = "Nenhum produto foi encontrado";
            }
            return View("~/Views/Roupa/List.cshtml", new RoupaListViewModel
            {
                Roupas = roupas,
                CategoriaAtual = categoriaAtual
            });

        }
    }
}
