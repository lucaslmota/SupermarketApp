using System.Threading.Tasks;
using api_rest.Domains.Repositories;

namespace api_rest.Persistence.Repositories
{
    public class UnitOfWork : IUnityOfWork
    {
        private readonly AppDbContext _context;

        public UnitOfWork(AppDbContext context)
        {
            _context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}