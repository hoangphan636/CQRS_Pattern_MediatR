
using CQRS_Pattern_với_MediatR.DataAccess;
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

        public async Task<IEnumerable<FlowerBouquet>> Handle(GetAllFlowerBouquetsQuery request, CancellationToken cancellationToken)
        {
            var flowerBouquetList = await _context.FlowerBouquets.ToListAsync();
            var teo = flowerBouquetList;
            return flowerBouquetList;
        }
        public async Task<IEnumerable<FlowerBouquet>> Handles(GetAllFlowerBouquetsQuery request, CancellationToken cancellationToken)
        {
            var flowerBouquetList = await _context.FlowerBouquets.ToListAsync();
            var teo = flowerBouquetList;
            return flowerBouquetList;
        }
    }
}
