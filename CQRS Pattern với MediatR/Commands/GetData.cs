using CQRS_Pattern_với_MediatR.DataAccess;

namespace CQRS_Pattern_với_MediatR.Commands
{
    public class GetData
    {
        private readonly FUFlowerBouquetManagementContext _context;

        public GetData(FUFlowerBouquetManagementContext context)
        {
            _context = context;
        }
        public List<FlowerBouquet> GetAll()
        {

            List<FlowerBouquet> data = _context.FlowerBouquets.ToList();

            return data;
        }


    }
}
