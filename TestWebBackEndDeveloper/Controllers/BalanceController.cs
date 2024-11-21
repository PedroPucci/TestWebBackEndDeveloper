using Microsoft.AspNetCore.Mvc;
using TestWebBackEndDeveloper.Application.UnitOfWork;
using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Controllers
{
    [ApiController]
    [Route("api/v1/balance")]
    public class BalanceController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        public BalanceController(IUnitOfWorkService unitOfWorkService)
        {
            _serviceUoW = unitOfWorkService;
        }

        [HttpGet("All Accounts")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<Balance>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetBalanceByAccount(int id)
        {
            var accounts = await _serviceUoW.BalanceService.GetBalanceByIdAccount(id);
            return Ok(accounts);
        }
    }
}