using GenericRepositoryAndService.ApplicationCore.Abstractions.Repositories;
using GenericRepositoryAndService.ApplicationCore.Data;
using Microsoft.EntityFrameworkCore;

namespace GenericRepositoryAndService
{
    public static class DbGetIncludeHandle
    {
        public static async Task Handler(IGenericRepository<Blog> blogRepository, IGenericRepository<Post> postRepository)
        {
            var getTask = blogRepository.ListAsync(
                orderBy: x => x.OrderBy(x => x.BlogId),
                include: x => x.Include(b => b.Posts),
                asNoTracking: true
            );

            foreach (var blog in await getTask)
            {
                Console.WriteLine($"BlogId: {blog.BlogId}, Url: {blog.Url}");

                if(blog.Posts != null)
                {
                    foreach (var post in blog.Posts)
                    {
                        Console.WriteLine($"\tPostId: {post.PostId}, Title: {post.Title}, Content: {post.Content}");
                    }
                }
            }
        }
    }
}
