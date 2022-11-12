using NetPants.Models;

namespace NetPants.ViewModels
{
    public class PedidoRoupaViewModel
    {
        public Pedido Pedido { get; set; }
        public IEnumerable<PedidoDetalhe> PedidoDetalhes { get; set; }
    }
}
