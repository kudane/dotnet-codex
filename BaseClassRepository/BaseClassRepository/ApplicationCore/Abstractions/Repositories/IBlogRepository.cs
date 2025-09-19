using BaseClassRepository.ApplicationCore.Dtos;

namespace BaseClassRepository.ApplicationCore.Abstractions.Repositories
{
    public interface IBlogRepository
    {
        Task BulkCreateAsync(BlogCreateBulk dto);
    }
}
