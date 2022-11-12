using NetPants.Models;

namespace NetPants.ViewModels
{
    public class RoupaListViewModel
    {
        public IEnumerable<Roupa> Roupas { get; set; }
        public string CategoriaAtual { get; set; }
    }
}
