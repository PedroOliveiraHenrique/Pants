using Microsoft.AspNetCore.Mvc;
using NetPants.Models;
using NetPants.Repositories.Interfaces;
using NetPants.ViewModels;
using System.Diagnostics;

namespace NetPants.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRoupaRepository _roupaRepository;

        public HomeController(IRoupaRepository roupaRepository)
        {
            _roupaRepository = roupaRepository;
        }

        public IActionResult Index()
        {
            var homeViewModel = new HomeViewModel
            {
                RoupaPromocao = _roupaRepository.RoupasPromocao
            };
            return View(homeViewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}