using BaseClassRepository.ApplicationCore.Data;
using BaseClassRepository.ApplicationCore.Dtos;

namespace BaseClassRepository.ApplicationCore.Abstractions.Repositories
{
    public interface IPostRepository
    {
        Task<IReadOnlyList<Post>> GetPostByMultipleBlogId(IEnumerable<int> blogIdList);
        Task<IReadOnlyList<Lookup>> GetPostLookup();
    }
}