using Microsoft.Extensions.DependencyInjection;
using PackIt.Shared.Abstractions.Commands;
using System.Reflection;

namespace PackIt.Shared.Commands
{
    public static class Extensions
    {
        /// <summary>
        /// Registers the command dispatcher and all command handlers defined in the calling assembly
        /// into the dependency injection container.
        /// </summary>
        /// <remarks>
        /// <para>
        /// This method performs two registrations:
        /// <list type="bullet">
        ///   <item>
        ///     <description>
        ///       Registers <see cref="InMemoryCommandDispatcher"/> as a singleton implementation
        ///       of <see cref="ICommandDispatcher"/>.
        ///     </description>
        ///   </item>
        ///   <item>
        ///     <description>
        ///       Scans the calling assembly and registers all classes implementing
        ///       <see cref="ICommandHandler{TCommand}"/> as scoped services under their implemented interfaces.
        ///     </description>
        ///   </item>
        /// </list>
        /// </para>
        /// <para>
        /// Command handlers are automatically discovered via assembly scanning — no manual registration is needed.
        /// Simply implement <see cref="ICommandHandler{TCommand}"/> and call this method once during startup.
        /// </para>
        /// <para>
        /// <b>Important:</b> This method uses <see cref="Assembly.GetCallingAssembly"/> to resolve handlers,
        /// so it must be called directly from the assembly that contains your command handler implementations,
        /// not from a wrapper or intermediary method.
        /// </para>
        /// </remarks>
        /// <param name="services">The <see cref="IServiceCollection"/> to register services into.</param>
        /// <returns>
        /// The same <see cref="IServiceCollection"/> instance, allowing further chained calls.
        /// </returns>
        /// <example>
        /// Register commands in your startup or program entry point:
        /// <code>
        /// // Program.cs
        /// var builder = WebApplication.CreateBuilder(args);
        /// builder.Services.AddCommands();
        /// </code>
        ///
        /// Define a command and its handler in the same assembly:
        /// <code>
        /// // CreateOrderCommand.cs
        /// public record CreateOrderCommand(Guid OrderId, string ProductName) : ICommand;
        ///
        /// // CreateOrderCommandHandler.cs
        /// public class CreateOrderCommandHandler : ICommandHandler&lt;CreateOrderCommand&gt;
        /// {
        ///     public Task HandleAsync(CreateOrderCommand command)
        ///     {
        ///         // handle the command...
        ///         return Task.CompletedTask;
        ///     }
        /// }
        /// </code>
        ///
        /// Dispatch a command via <see cref="ICommandDispatcher"/>:
        /// <code>
        /// public class OrderController : ControllerBase
        /// {
        ///     private readonly ICommandDispatcher _dispatcher;
        ///
        ///     public OrderController(ICommandDispatcher dispatcher)
        ///         => _dispatcher = dispatcher;
        ///
        ///     [HttpPost]
        ///     public async Task&lt;IActionResult&gt; Create(CreateOrderCommand command)
        ///     {
        ///         await _dispatcher.SendAsync(command);
        ///         return Ok();
        ///     }
        /// }
        /// </code>
        /// </example>
        /// <exception cref="InvalidOperationException">
        /// May be thrown if no suitable <see cref="ICommandHandler{TCommand}"/> implementations
        /// are found, depending on the dispatcher implementation.
        /// </exception>
        public static IServiceCollection AddCommands(this IServiceCollection services)
        {
            var assembly = Assembly.GetCallingAssembly();

            services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();

            services.Scan(s => s.FromAssemblies(assembly)
                .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
                .AsImplementedInterfaces()
                .WithScopedLifetime()
            );

            return services;
        }
    }
}
