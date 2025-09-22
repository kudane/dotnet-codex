namespace BaseClassRepositoryAndExtension.ApplicationCore.Exceptions
{
    public class Error : Exception
    {
        public Error() { }

        public Error(string message)
            : base(message) { }

        public Error(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
