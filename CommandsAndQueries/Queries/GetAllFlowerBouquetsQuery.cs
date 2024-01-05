using Database.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace CommandsAndQueries.Queries
{
    public class GetAllFlowerBouquetsQuery : IRequest<IEnumerable<FlowerBouquet>> { }

    public class GetAllFlowerBouquetsQueryHandler : IRequestHandler<GetAllFlowerBouquetsQuery, IEnumerable<FlowerBouquet>>
    {
        private readonly FUFlowerBouquetManagementContext _context;

        public GetAllFlowerBouquetsQueryHandler(FUFlowerBouquetManagementContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<FlowerBouquet>> Handle(GetAllFlowerBouquetsQuery query, CancellationToken cancellationToken)
        {
            var flowerBouquetList = await _context.FlowerBouquets.ToListAsync();

            return flowerBouquetList?.AsReadOnly();
        }
    }
}
