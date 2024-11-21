using Microsoft.AspNetCore.Mvc;
using TestWebBackEndDeveloper.Application.UnitOfWork;
using TestWebBackEndDeveloper.Domain.Entity;

namespace TestWebBackEndDeveloper.Controllers
{
    [ApiController]
    [Route("api/v1/quotation")]
    public class QuotationController : Controller
    {
        private readonly IUnitOfWorkService _serviceUoW;

        public QuotationController(IUnitOfWorkService unitOfWorkService)
        {
            _serviceUoW = unitOfWorkService;
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> AddQuotation([FromBody] Quotation quotation)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var result = await _serviceUoW.QuotationService.AddQuotationAsync(quotation);
            return result.Success ? Ok(result) : BadRequest(result);
        }

        [HttpGet("All")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AccountUser>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllQuotations()
        {
            var accounts = await _serviceUoW.QuotationService.GetAllQuotationsAsync();
            return Ok(accounts);
        }

        [HttpGet("All QuotationsBuy")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AccountUser>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllQuotationsBuy()
        {
            var accounts = await _serviceUoW.QuotationService.GetAllQuotationsBuyAsync();
            return Ok(accounts);
        }

        [HttpGet("All QuotationsSell")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(List<AccountUser>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> GetAllQuotationsSell()
        {
            var accounts = await _serviceUoW.QuotationService.GetAllQuotationsSellAsync();
            return Ok(accounts);
        }
    }
}