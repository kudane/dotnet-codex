using GenericRepositoryAndService.ApplicationCore.Data;
using GenericRepositoryAndService.ApplicationCore.Exceptions;

namespace GenericRepositoryAndService.ApplicationCore.Dtos
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
