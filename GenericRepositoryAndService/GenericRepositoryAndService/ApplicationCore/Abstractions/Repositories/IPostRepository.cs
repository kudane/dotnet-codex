using GenericRepositoryAndService.ApplicationCore.Data;
using GenericRepositoryAndService.ApplicationCore.Dtos;

namespace GenericRepositoryAndService.ApplicationCore.Abstractions.Repositories
{
    public interface IPostRepository
    {
        Task<IEnumerable<Post>> GetPostByMultipleBlogId(IEnumerable<int> blogIdList);
        Task<IEnumerable<Lookup>> GetPostLookup();
    }
}
