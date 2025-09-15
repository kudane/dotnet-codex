namespace GenericRepositoryAndService.ApplicationCore.Abstractions.Repositories
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken ct = default);
    }
}
