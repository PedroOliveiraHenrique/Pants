using Microsoft.EntityFrameworkCore;
using NetPants.Context;
using NetPants.Models;
using NetPants.Repositories.Interfaces;

namespace NetPants.Repositories
{
    public class RoupaRepository : IRoupaRepository
    {
        private readonly AppDbContext _context;
        public RoupaRepository(AppDbContext contexto)
        {
            _context = contexto;
        }

        public IEnumerable<Roupa> Roupas => _context.Roupas.Include(c => c.Categoria);

        public IEnumerable<Roupa> RoupasPromocao => _context.Roupas
            .Where(l => l.IsRoupaPromocao)
            .Include(c => c.Categoria);

        public Roupa GetRoupaById(int roupaId)
        {
            return _context.Roupas.FirstOrDefault(l => l.RoupaId == roupaId);
        }
    }
}
