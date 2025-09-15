using GenericRepositoryAndService.ApplicationCore.Exceptions;

namespace GenericRepositoryAndService.ApplicationCore.Dtos
{
    public record Lookup
    {
        public int Id { get; init; }
        public string Value { get; init; }

        public Lookup(int id, string value)
        {
            Guard.AgainstNegativeOrZero(id, "Lookup.Id");
            Guard.AgainstNullOrEmpty(value, "Lookup.Value");
            Id = id;
            Value = value;
        }
    };
}
