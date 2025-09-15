using GenericRepositoryAndService.ApplicationCore.Abstractions.Repositories;
using GenericRepositoryAndService.ApplicationCore.Data;

namespace GenericRepositoryAndService
{
    public static class InsertHandle
    {
        public static async Task Handler(IUnitOfWork uow, IGenericRepository<Blog> blogRepository, IGenericRepository<Post> postRepository)
        {
            await blogRepository.CreateAsync(
                new Blog { BlogId = 1, Url = "https://example.com/blog1" }
            );

            await blogRepository.CreateAsync(
                new Blog { BlogId = 2, Url = "https://example.com/blog2" }
            );

            await postRepository.CreateAsync(
                new Post { PostId =1, BlogId = 1, Title = "Post 1", Content = "Content 1" }
            );

            await postRepository.CreateAsync(
                new Post { PostId = 2, BlogId = 1, Title = "Post 2", Content = "Content 2" }
            );

            await postRepository.CreateAsync(
                new Post { PostId = 3, BlogId = 2, Title = "Post 3", Content = "Content 3" }
            );

            await uow.SaveChangesAsync();
        }
    }
}
