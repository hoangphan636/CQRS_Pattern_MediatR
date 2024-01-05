
using CQRS_Pattern_với_MediatR.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsAndQueries.Commands
{
    public class UpdateFlowerBouquetCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string FlowerBouquetName { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public class UpdateFlowerBouquetCommandHandler : IRequestHandler<UpdateFlowerBouquetCommand, int>, IUpdateFlowerBouquetCommandHandler
        {
            private readonly FUFlowerBouquetManagementContext _context;
            public UpdateFlowerBouquetCommandHandler(FUFlowerBouquetManagementContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(UpdateFlowerBouquetCommand command, CancellationToken cancellationToken)
            {
                var FlowerBouquet = _context.FlowerBouquets.Where(a => a.FlowerBouquetId.Equals(command.Id)).FirstOrDefault();

                if (FlowerBouquet == null)
                {
                    return default;
                }
                else
                {
                    FlowerBouquet.FlowerBouquetName = command.FlowerBouquetName;
                    FlowerBouquet.Description = command.Description;
                    FlowerBouquet.UnitPrice = command.UnitPrice;
                    FlowerBouquet.UnitsInStock = command.UnitsInStock;
                    await _context.SaveChangesAsync();
                    return FlowerBouquet.FlowerBouquetId;
                }
            }
        }
    }
}
