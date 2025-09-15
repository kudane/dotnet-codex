using GenericRepositoryAndService.ApplicationCore.Abstractions.Repositories;
using GenericRepositoryAndService.ApplicationCore.Data;
using GenericRepositoryAndService.ApplicationCore.Dtos;

namespace GenericRepositoryAndService.Infrastructure.Repositories
{
    public class PostRepository(IGenericRepository<Post> postRepository) : IPostRepository
    {
        private readonly IGenericRepository<Post> _postRepository = postRepository;

        public async Task<IEnumerable<Post>> GetPostByMultipleBlogId(IEnumerable<int> blogIdList)
        {
            blogIdList ??= [];

            var items = await _postRepository.ListAsync((x) => blogIdList.Any(y => y == x.BlogId));

            return items;
        }

        public async Task<IEnumerable<Lookup>> GetPostLookup()
        {
            var items = await _postRepository.ListAsync(asNoTracking: true);

            var lookupItems = items.Select(x => new Lookup(x.PostId, x.Title));

            return lookupItems;
        }
    }
}
