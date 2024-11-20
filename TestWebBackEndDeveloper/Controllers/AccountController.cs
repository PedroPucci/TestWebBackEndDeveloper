using Microsoft.AspNetCore.Mvc;
using TestWebBackEndDeveloper.Application.UnitOfWork;
using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Controllers
{
    [ApiController]
    [Route("api/v1/account")]
    public class AccountController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        public AccountController(IUnitOfWorkService unitOfWorkService)
        {
            _serviceUoW = unitOfWorkService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddAccount([FromBody] AccountUser accountUser)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _serviceUoW.AccountService.AddAccountUserAsync(accountUser);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> UpdateAccount([FromBody] AccountUser accountUser)
        {
            var result = await _serviceUoW.AccountService.UpdateAccountUserAsync(accountUser);
            return result.Success ? Ok(result) : BadRequest(accountUser);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesDefaultResponseType]
        public async Task<IActionResult> DeleteAccount(int id)
        {
            await _serviceUoW.AccountService.DeleteAccountUserAsync(id);
            return Ok();
        }

        [HttpGet("All Accounts")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AccountUser>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllAccounts()
        {
            var accounts = await _serviceUoW.AccountService.GetAllAccountUsersAsync();
            return Ok(accounts);
        }
    }
}