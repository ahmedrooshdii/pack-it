using Microsoft.Extensions.DependencyInjection;
using PackIt.Shared.Abstractions.Queries;

namespace PackIt.Shared.Queries
{
    internal sealed class InMemoryQueryDispatcher : IQueryDispatcher
    {
        private readonly IServiceProvider _serviceProvider;

        public InMemoryQueryDispatcher(IServiceProvider serviceProvider)
            => _serviceProvider = serviceProvider;

        public async Task<TResult> DispatchAsync<TResult>(IQuery<TResult> query)
        {
            using var scope = _serviceProvider.CreateScope();

            var handlerType = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TResult));
            var handler = scope.ServiceProvider.GetRequiredService(handlerType);

            var method = handlerType.GetMethod(nameof(IQueryHandler<IQuery<TResult>, TResult>.HandleAsync));
            var result = method?.Invoke(handler, new object[] { query });

            if (result is Task<TResult> task)
            {
                return await task;
            }

            throw new InvalidOperationException($"Handler for {typeof(TResult).Name} did not return a valid Task.");
        }
    }
}
