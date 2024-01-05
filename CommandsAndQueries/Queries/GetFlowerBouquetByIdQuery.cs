using Database.DataAccess;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CommandsAndQueries.Queries
{
    public class GetFlowerBouquetByIdQuery : IRequest<FlowerBouquet>
    {
        public int Id { get; set; }
        public class GetFlowerBouquetByIdQueryHandler : IRequestHandler<GetFlowerBouquetByIdQuery, FlowerBouquet>
        {
            private readonly FUFlowerBouquetManagementContext _context;
            public GetFlowerBouquetByIdQueryHandler(FUFlowerBouquetManagementContext context)
            {
                _context = context;
            }
            public async Task<FlowerBouquet> Handle(GetFlowerBouquetByIdQuery query, CancellationToken cancellationToken)
            {
                var FlowerBouquet = _context.FlowerBouquets.Where(a => a.FlowerBouquetId.Equals(query.Id)).FirstOrDefault();
                if (FlowerBouquet == null) return null;
                return FlowerBouquet;
            }
        }
    }
}
