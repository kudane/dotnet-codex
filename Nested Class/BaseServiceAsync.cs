// https://github.com/ardalis/ApiEndpoints
// https://github.com/jbogard/MediatR

public static class BaseServiceAsync
{
    public static class WithInput<TInput>
    {
        public abstract class WithOutput<TOutput> 
        {
            public abstract Task<TOutput> HandleAsync(
                TInput Input,
                CancellationToken cancellationToken = default
            );
        }

        public abstract class NoOutput
        {
            public abstract Task HandleAsync(
                TInput Input,
                CancellationToken cancellationToken = default
            );
        }
    }

    public static class NoInput
    {
        public abstract class WithOutput<TOutput>
        {
            public abstract Task<TOutput> HandleAsync(
                CancellationToken cancellationToken = default
            );
        }

        public abstract class NoOutput
        {
            public abstract Task HandleAsync(
                CancellationToken cancellationToken = default
            );
        }
    }
}
