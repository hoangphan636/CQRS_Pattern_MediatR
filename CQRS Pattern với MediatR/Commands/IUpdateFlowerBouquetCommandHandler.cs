
namespace CommandsAndQueries.Commands
{
    public interface IUpdateFlowerBouquetCommandHandler
    {
        Task<int> Handle(UpdateFlowerBouquetCommand command, CancellationToken cancellationToken);
    }
}