
using CQRS_Pattern_với_MediatR.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsAndQueries.Commands
{
    public class CreateFlowerBouquetCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string FlowerBouquetName { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public int UnitsInStock { get; set; }
        public class CreateFlowerBouquetCommandHandler : IRequest<int>, ICreateFlowerBouquetCommandHandler
        {
            private readonly FUFlowerBouquetManagementContext _context;
            public CreateFlowerBouquetCommandHandler(FUFlowerBouquetManagementContext context)
            {
                _context = context;
            }
            public async Task<int> Handle(CreateFlowerBouquetCommand command, CancellationToken cancellationToken)
            {
                var FlowerBouquet = new FlowerBouquet();
                FlowerBouquet.FlowerBouquetName = command.FlowerBouquetName;
                FlowerBouquet.Description = command.Description;
                FlowerBouquet.UnitPrice = command.UnitPrice;
                FlowerBouquet.UnitsInStock = command.UnitsInStock;
                _context.FlowerBouquets.Add(FlowerBouquet);
                await _context.SaveChangesAsync();
                return FlowerBouquet.FlowerBouquetId;
            }
        }
    }
}
