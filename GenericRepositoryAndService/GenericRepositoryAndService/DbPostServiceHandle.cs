using GenericRepositoryAndService.ApplicationCore.Abstractions.Repositories;

namespace GenericRepositoryAndService
{
    public static class DbPostServiceHandle
    {
        public static async Task Handler(IPostRepository postRepository)
        {
            var getTask1 = postRepository.GetPostByMultipleBlogId([1, 2]);

            foreach (var item in await getTask1)
            {                 
                Console.WriteLine($"Post By Multiple BlogId: {item.PostId}, {item.Title}, {item.BlogId}");
            }   

            var getTask2 = postRepository.GetPostLookup();

            foreach (var item in await getTask1)
            {
                Console.WriteLine($"Post By Multiple BlogId: {item.PostId}, {item.Title}, {item.BlogId}");
            }
        }
    }
}
