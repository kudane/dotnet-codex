using BaseClassRepositoryAndExtension.ApplicationCore.Data;
using BaseClassRepositoryAndExtension.ApplicationCore.Exceptions;

namespace BaseClassRepositoryAndExtension.ApplicationCore.Dtos
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
