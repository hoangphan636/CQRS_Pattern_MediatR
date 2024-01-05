
namespace CommandsAndQueries.Commands
{
    public interface ICreateFlowerBouquetCommandHandler
    {
        Task<int> Handle(CreateFlowerBouquetCommand command, CancellationToken cancellationToken);
    }
}