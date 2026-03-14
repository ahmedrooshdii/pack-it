namespace PackIt.Shared.Abstractions.Commands
{
    public interface ICommandHandler<TCommand> where TCommand : class, ICommand
    {
        Task HandleAsync(ICommand command, CancellationToken cancellationToken = default);
    }
}
