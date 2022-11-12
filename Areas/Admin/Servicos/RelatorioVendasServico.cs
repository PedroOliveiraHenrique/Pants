using Microsoft.EntityFrameworkCore;
using NetPants.Context;
using NetPants.Models;

namespace NetPants.Areas.Admin.Servicos
{
    public class RelatorioVendasServico
    {
        private readonly AppDbContext context;

        public RelatorioVendasServico(AppDbContext _context)
        {
            context = _context;
        }
        public async Task<List<Pedido>> FindByDateAsync(DateTime?
            minDate, DateTime? maxDate)
        {
            var resultado = from obj in context.Pedidos select obj;

            if (minDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado >= minDate.Value);
            }
            if (maxDate.HasValue)
            {
                resultado = resultado.Where(x => x.PedidoEnviado <= maxDate.Value);
            }

            return await resultado
                .Include(l => l.PedidoItens)
                .ThenInclude(l => l.Roupa)
                .OrderByDescending(x => x.PedidoEnviado)
                .ToListAsync();
        }
    }
}
