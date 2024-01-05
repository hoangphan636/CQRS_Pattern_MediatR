using Database.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsAndQueries.Commands
{
    public class DeleteFlowerBouquetByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class DeleteFlowerBouquetByIdCommandHandler : IRequestHandler<DeleteFlowerBouquetByIdCommand, int>
        {
            private readonly FUFlowerBouquetManagementContext _context;
            public DeleteFlowerBouquetByIdCommandHandler(FUFlowerBouquetManagementContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(DeleteFlowerBouquetByIdCommand command, CancellationToken cancellationToken)
            {
                var FlowerBouquet = await _context.FlowerBouquets.Where(a => a.FlowerBouquetId == command.Id).FirstOrDefaultAsync();
                if (FlowerBouquet == null) return default;
                _context.FlowerBouquets.Remove(FlowerBouquet);
                await _context.SaveChangesAsync();
                return FlowerBouquet.FlowerBouquetId;
            }
        }
    }
}
