using NetPants.Models;

namespace NetPants.Repositories.Interfaces
{
    public interface IRoupaRepository
    {
        IEnumerable<Roupa> Roupas { get; }
        IEnumerable<Roupa> RoupasPromocao { get; }
        Roupa GetRoupaById(int roupaId);
    }
}
