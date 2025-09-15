using GenericRepositoryAndService.ApplicationCore.Abstractions.Repositories;
using GenericRepositoryAndService.ApplicationCore.Data;
using GenericRepositoryAndService.ApplicationCore.Dtos;

namespace GenericRepositoryAndService
{
    public static class DbBlogServiceHandle
    {
        public static async Task Handler(IUnitOfWork uow, IBlogRepository blogRepository)
        {
            var dto = new BlogCreateBulk([
                new Blog()
                {
                    BlogId = 3,
                    Url = "https://example.com/blog3",
                },
                new Blog()
                {
                    BlogId = 4,
                    Url = "https://example.com/blog4",
                },
                new Blog()
                {
                    BlogId = 5,
                    Url = "https://example.com/blog5",
                },
            ]);

            await blogRepository.BulkCreateAsync(dto);

            await uow.SaveChangesAsync();
        }
    }
}
