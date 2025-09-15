using GenericRepositoryAndService.ApplicationCore.Abstractions.Repositories;
using GenericRepositoryAndService.ApplicationCore.Data;

namespace GenericRepositoryAndService.Infrastructure.Repositories
{
    public class UnitOfWork(BloggingContext context) : IUnitOfWork
    {
        private readonly BloggingContext _context = context;

        public async Task<int> SaveChangesAsync(CancellationToken ct = default)
        {
            return await _context.SaveChangesAsync(ct);
        }
    }
}
