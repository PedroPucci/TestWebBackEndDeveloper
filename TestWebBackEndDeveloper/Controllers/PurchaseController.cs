using Microsoft.AspNetCore.Mvc;
using TestWebBackEndDeveloper.Application.UnitOfWork;
using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Controllers
{
    [ApiController]
    [Route("api/v1/purchase")]
    public class PurchaseController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        public PurchaseController(IUnitOfWorkService unitOfWorkService)
        {
            _serviceUoW = unitOfWorkService;
        }

        [HttpPost("Buy Bitcoin")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddBitcoinAsync([FromBody] Purchase purchase)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _serviceUoW.PurchaseService.AddBitcoinAsync(purchase);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}