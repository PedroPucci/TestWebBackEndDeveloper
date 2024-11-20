using Microsoft.AspNetCore.Mvc;
using TestWebBackEndDeveloper.Application.UnitOfWork;
using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Controllers
{
    [ApiController]
    [Route("api/v1/deposit")]
    public class DepositController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        public DepositController(IUnitOfWorkService unitOfWorkService)
        {
            _serviceUoW = unitOfWorkService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddDeposit([FromBody] Deposit deposit)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _serviceUoW.DepositService.AddDepositAsync(deposit);
            return result.Success ? Ok(result) : BadRequest(result);
        }
    }
}