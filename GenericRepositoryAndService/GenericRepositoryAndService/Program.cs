using GenericRepositoryAndService;
using GenericRepositoryAndService.ApplicationCore.Abstractions.Repositories;
using GenericRepositoryAndService.ApplicationCore.Data;
using GenericRepositoryAndService.Infrastructure.Repositories;

using var db = new BloggingContext();
var uow = new UnitOfWork(db);
var blogRepository = (IGenericRepository<Blog>)new GenericRepository<Blog>(db);
var postRepository = (IGenericRepository<Post>)new GenericRepository<Post>(db);
var blogService = (IBlogRepository)new BlogRepository();
var postService = (IPostRepository)new PostRepository(postRepository);

if (false)
{
    await InsertHandle.Handler(uow, blogRepository, postRepository);
}
await DbGetBasicHandle.Handler(blogRepository, postRepository);
await DbGetIncludeHandle.Handler(blogRepository, postRepository);
await DbBlogServiceHandle.Handler(uow, blogService);
await DbPostServiceHandle.Handler(postService);
