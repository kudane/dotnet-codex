using BaseClassRepository.ApplicationCore.Abstractions.Repositories;
using BaseClassRepository.ApplicationCore.Data;
using BaseClassRepository.ApplicationCore.Dtos;

namespace BaseClassRepository.Infrastructure.Repositories
{
    public class BlogRepository : BaseRepository<Blog>, IBlogRepository
    {
        public BlogRepository(BloggingContext context) : base(context)
        {
        }

        public Task BulkCreateAsync(BlogCreateBulk dto)
        {
            Console.WriteLine("BlogRepository.BulkCreateAsync called");
            return Task.CompletedTask;
        }
    }
}
