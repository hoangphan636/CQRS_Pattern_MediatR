using commandsandqueries.commands;
using CommandsAndQueries.Commands;

namespace CQRS_Pattern_với_MediatR.Commands
{
    public interface IDeleteFlowerBouquetCommandHandler
    {
        Task<int> Handle(deleteflowerbouquetbyidcommand command, CancellationToken cancellationToken);

    }
}
