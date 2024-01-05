using commandsandqueries.commands;
using CommandsAndQueries.Commands;
using CommandsAndQueries.Queries;
using CQRS_Pattern_với_MediatR.Commands;
using CQRS_Pattern_với_MediatR.DataAccess;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Pattern_với_MediatR.Controllers
{
    [ApiController]
    [Route("api/Product")]

    public class ProductsController : ControllerBase, IProductsController
    {
        private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public IActionResult Get()
        {
            FUFlowerBouquetManagementContext context = new FUFlowerBouquetManagementContext(); // Initialize your context here

            GetData getDataInstance = new GetData(context);

            try
            {
                List<FlowerBouquet> flowerBouquets = getDataInstance.GetAll();
                return Ok(flowerBouquets);
            }
            catch (Exception ex)
            {
                // Handle exception appropriately, e.g., log it or return an error response
                return StatusCode(500, $"Internal Server Error: {ex.Message}");
            }
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            return Ok(await _mediator.Send(new GetFlowerBouquetByIdQuery { Id = id }));
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateFlowerBouquetCommand command)
        {
            return Ok(await _mediator.Send(command));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, UpdateFlowerBouquetCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }
            return Ok(await _mediator.Send(command));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _mediator.Send(new deleteflowerbouquetbyidcommand { id = id }));
        }

        Task<IActionResult> IProductsController.Get()
        {
            throw new NotImplementedException();
        }
    }
}