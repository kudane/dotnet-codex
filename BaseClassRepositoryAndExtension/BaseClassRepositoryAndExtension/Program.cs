using BaseClassRepositoryAndExtension.ApplicationCore.Abstractions.Repositories;
using BaseClassRepositoryAndExtension.ApplicationCore.Data;
using BaseClassRepositoryAndExtension.Infrastructure.Repositories;

using var db = new BloggingContext();

var postRepository = (IPostRepository)new PostRepository(db);

var items = await postRepository.GetPostByMultipleBlogIdAsync([1, 2]);

foreach (var item in items)
{
    Console.WriteLine($"PostId: {item.PostId}, Title: {item.Title}, BlogId: {item.BlogId}");
}

var items2 = await postRepository.GetPostLookupAsync();

foreach (var kvp in items2)
{
    Console.WriteLine($"PostId: {kvp.Id}, Title: {kvp.Value}");
}