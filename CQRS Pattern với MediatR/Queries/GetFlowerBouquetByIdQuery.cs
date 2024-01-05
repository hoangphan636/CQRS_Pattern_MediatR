using CQRS_Pattern_với_MediatR.DataAccess;
using MediatR;
using System;
using System.Linq;
using System.Threading;
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
                var FlowerBouquet = _context.FlowerBouquets
                    .Where(a => a.FlowerBouquetId.Equals(query.Id)).FirstOrDefault();
                // FirstOrDefault() nếu không có đối tượng nào thỏa mãn,
                // FlowerBouquet sẽ là null

                // Kiểm tra nếu yêu cầu đã bị hủy
                if (cancellationToken.IsCancellationRequested)
                {
                    // Xử lý hủy bỏ nếu cần thiết
                    // Ví dụ: throw một ngoại lệ để thông báo về việc hủy bỏ
                    throw new TaskCanceledException("The operation was canceled.");
                }

                if (FlowerBouquet == null)
                {
                    return null;
                }

                return FlowerBouquet;
            }
        }
    }
}
