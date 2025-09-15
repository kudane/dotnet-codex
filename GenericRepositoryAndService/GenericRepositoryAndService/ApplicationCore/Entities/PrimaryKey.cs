using GenericRepositoryAndService.ApplicationCore.Exceptions;

namespace GenericRepositoryAndService.ApplicationCore.Entities
{
    public class PrimaryKey
    {
        private int _id { get; init; }

        public PrimaryKey(int id)
        {
            Guard.AgainstNegativeOrZero(id, "PrimaryKey.Id");
            _id = id;
        }

        public int Get() => _id;
    }
}
