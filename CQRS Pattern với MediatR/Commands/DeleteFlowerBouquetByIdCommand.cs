
using CQRS_Pattern_với_MediatR.Commands;
using CQRS_Pattern_với_MediatR.DataAccess;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace commandsandqueries.commands
{
    public class deleteflowerbouquetbyidcommand : IRequest<int>
    {
        public int id { get; set; }
        public class Deleteflowerbouquetbyidcommandhandler : IRequestHandler<deleteflowerbouquetbyidcommand,int>, IDeleteFlowerBouquetCommandHandler
        {
            private readonly FUFlowerBouquetManagementContext _context;
            public Deleteflowerbouquetbyidcommandhandler(FUFlowerBouquetManagementContext context)
            {
                _context = context;
            }
         

            public async Task<int> Handle(deleteflowerbouquetbyidcommand command, CancellationToken cancellationToken)
            {
                var flowerbouquet = await _context.FlowerBouquets.Where(a => a.FlowerBouquetId == command.id).FirstOrDefaultAsync();
                if (flowerbouquet == null) return default;
                _context.FlowerBouquets.Remove(flowerbouquet);
                await _context.SaveChangesAsync();
                return flowerbouquet.FlowerBouquetId;
            }
        }
    }
}
