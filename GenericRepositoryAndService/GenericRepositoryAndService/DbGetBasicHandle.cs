using GenericRepositoryAndService.ApplicationCore.Abstractions.Repositories;
using GenericRepositoryAndService.ApplicationCore.Data;

namespace GenericRepositoryAndService
{
    public static class DbGetBasicHandle
    {
        public static async Task Handler(IGenericRepository<Blog> blogRepository, IGenericRepository<Post> postRepository)
        {
            var getTask = blogRepository.ListAsync(
                filter: x => x.BlogId == 1,
                orderBy: x => x.OrderByDescending(x => x.BlogId),
                asNoTracking: true
            );

            foreach (var blog in await getTask)
            {
                Console.WriteLine($"BlogId: {blog.BlogId}, Url: {blog.Url}");
            }

            var getTask2 = postRepository.ListAsync(
                filter: x => x.BlogId == 1,
                orderBy: x => x.OrderByDescending(x => x.BlogId),
                asNoTracking: true
            );

            foreach (var post in await getTask2)
            {
                Console.WriteLine($"PostId: {post.PostId}, Title: {post.Title}, Content: {post.Content}, BlogId: {post.BlogId}");
            }
        }
    }
}
