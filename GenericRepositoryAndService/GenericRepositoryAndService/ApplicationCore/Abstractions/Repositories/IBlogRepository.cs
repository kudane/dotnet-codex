using GenericRepositoryAndService.ApplicationCore.Data;
using GenericRepositoryAndService.ApplicationCore.Dtos;

namespace GenericRepositoryAndService.ApplicationCore.Abstractions.Repositories
{
    public interface IBlogRepository
    {
        Task BulkCreateAsync(BlogCreateBulk dto);
    }
}
