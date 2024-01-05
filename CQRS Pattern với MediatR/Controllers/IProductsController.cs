using CommandsAndQueries.Commands;
using Microsoft.AspNetCore.Mvc;

namespace CQRS_Pattern_với_MediatR.Controllers
{
    public interface IProductsController
    {
        Task<IActionResult> Create(CreateFlowerBouquetCommand command);
        Task<IActionResult> Delete(int id);
        Task<IActionResult> Get();
        Task<IActionResult> GetById(int id);
        Task<IActionResult> Update(int id, UpdateFlowerBouquetCommand command);
    }
}