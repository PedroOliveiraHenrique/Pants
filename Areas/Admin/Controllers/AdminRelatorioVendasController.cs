using Microsoft.AspNetCore.Mvc;
using NetPants.Areas.Admin.Servicos;

namespace NetPants.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminRelatorioVendasController : Controller
    {
        private readonly RelatorioVendasServico relatorioVendasServico;

        public AdminRelatorioVendasController(RelatorioVendasServico _relatorioVendasServico)
        {
            relatorioVendasServico = _relatorioVendasServico;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> RelatorioVendasSimples(DateTime? minDate,
            DateTime? maxDate)
        {
            if (!minDate.HasValue)
            {
                minDate = new DateTime(DateTime.Now.Year, 1, 1);
            }

            if (!maxDate.HasValue)
            {
                maxDate = DateTime.Now;
            }

            ViewData["minDate"] = minDate.Value.ToString("yyyy-MM-dd");
            ViewData["maxDate"] = maxDate.Value.ToString("yyyy-MM-dd");

            var result = await relatorioVendasServico.FindByDateAsync(minDate, maxDate);
            return View(result);
        }
    }
}
