using BaseClassRepositoryAndExtension.ApplicationCore.Data;
using BaseClassRepositoryAndExtension.ApplicationCore.Dtos;

namespace BaseClassRepositoryAndExtension.ApplicationCore.Abstractions.Repositories
{
    public interface IPostRepository
    {
        Task<IReadOnlyList<Post>> GetPostByMultipleBlogIdAsync(IEnumerable<int> blogIdList);
        Task<IReadOnlyList<Lookup>> GetPostLookupAsync();
    }
}