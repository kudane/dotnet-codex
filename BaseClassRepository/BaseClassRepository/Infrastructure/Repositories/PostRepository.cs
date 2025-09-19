using BaseClassRepository.ApplicationCore.Abstractions.Repositories;
using BaseClassRepository.ApplicationCore.Data;
using BaseClassRepository.ApplicationCore.Dtos;

namespace BaseClassRepository.Infrastructure.Repositories
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        public PostRepository(BloggingContext context) : base(context)
        {
        }

        public async Task<IReadOnlyList<Post>> GetPostByMultipleBlogId(IEnumerable<int> blogIdList)
        {
            blogIdList ??= [];

            var items = await ListAsync((x) => blogIdList.Any(y => y == x.BlogId));

            return items;
        }

        public async Task<IReadOnlyList<Lookup>> GetPostLookup()
        {
            var items = await ListAsync(asNoTracking: true);

            var lookupItems = items
                .Select(x => new Lookup(x.PostId, x.Title))
                .ToList();

            return lookupItems;
        }
    }
}
