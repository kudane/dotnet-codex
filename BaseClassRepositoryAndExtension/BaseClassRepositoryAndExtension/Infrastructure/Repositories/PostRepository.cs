using BaseClassRepositoryAndExtension.ApplicationCore.Abstractions.Repositories;
using BaseClassRepositoryAndExtension.ApplicationCore.Data;
using BaseClassRepositoryAndExtension.ApplicationCore.Dtos;
using BaseClassRepositoryAndExtension.Infrastructure.Repositories.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BaseClassRepositoryAndExtension.Infrastructure.Repositories
{
    public class PostRepository(BloggingContext context) : IPostRepository
    {
        private BloggingContext DbContext { get; } = context;

        public async Task<IReadOnlyList<Post>> GetPostByMultipleBlogIdAsync(IEnumerable<int> blogIdList) => await DbContext.Posts
            .WhereIf(blogIdList.Any(), x => blogIdList.Contains(x.BlogId))
            .ToListAsync();

        public async Task<IReadOnlyList<Lookup>> GetPostLookupAsync() => await DbContext.Posts
            .Select(x => new Lookup(x.PostId, x.Title))
            .ToListAsync();
    }
}
