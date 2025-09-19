using BaseClassRepository.ApplicationCore.Data;
using BaseClassRepository.ApplicationCore.Exceptions;

namespace BaseClassRepository.ApplicationCore.Dtos
{
    public record BlogCreateBulk
    {
        public IEnumerable<Blog> Blogs { get; init; }

        public BlogCreateBulk(IEnumerable<Blog> data)
        {
            Guard.AgainstEmptyCollection(data, "BlogCreateBulk.Blogs");
            Blogs = data;
        }
    }
}
