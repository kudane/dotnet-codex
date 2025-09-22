namespace BaseClassRepositoryAndExtension.ApplicationCore.Exceptions
{
    public static class Guard
    {
        public static void AgainstNull(object? value, string paramName)
        {
            if (value is null)
                throw new Error($"{paramName} should not be null.");
        }

        public static void AgainstNullOrEmpty(string? value, string paramName)
        {
            if (string.IsNullOrEmpty(value))
                throw new Error($"{paramName} should not be null or empty.");
        }

        public static void AgainstNullOrWhiteSpace(string? value, string paramName)
        {
            if (string.IsNullOrWhiteSpace(value))
                throw new Error($"{paramName} should not be null or whitespace.");
        }

        public static void AgainstOutOfRange(int value, int min, int max, string paramName)
        {
            if (value < min || value > max)
                throw new Error($"{paramName} must be between {min} and {max}. Actual: {value}");
        }

        public static void AgainstNegative(int value, string paramName)
        {
            if (value < 0)
                throw new Error($"{paramName} should not be negative. Actual: {value}");
        }

        public static void AgainstNegativeOrZero(int value, string paramName)
        {
            if (value <= 0)
                throw new Error($"{paramName} should be greater than zero. Actual: {value}");
        }

        public static void AgainstEmptyCollection<T>(IEnumerable<T>? collection, string paramName)
        {
            if (collection is null)
                throw new Error($"{paramName} should not be null.");

            if (!collection.Any())
                throw new Error($"{paramName} should not be empty.");
        }
    }
}
