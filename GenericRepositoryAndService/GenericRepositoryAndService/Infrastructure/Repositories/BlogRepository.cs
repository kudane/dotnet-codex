using GenericRepositoryAndService.ApplicationCore.Abstractions.Repositories;
using GenericRepositoryAndService.ApplicationCore.Dtos;

namespace GenericRepositoryAndService.Infrastructure.Repositories
{
    public class BlogRepository() : IBlogRepository
    {
        public Task BulkCreateAsync(BlogCreateBulk dto)
        {
            Console.WriteLine("BlogRepository.BulkCreateAsync called");
            return Task.CompletedTask;
        }
    }
}
