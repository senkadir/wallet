using Core.Services;
using Domain.Commands;
using Domain.Queries;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers
{
    [ApiController]
    [Route("expenses")]
    public class ExpenseController : ControllerBase
    {
        private readonly IExpenseService _expenseService;

        public ExpenseController(IExpenseService expenseService)
        {
            _expenseService = expenseService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateExpense([FromBody] CreateExpenseCommand command)
        {
            await _expenseService.CreateAsync(command);

            return Ok();
        }

        [HttpGet("{periodId:guid}")]
        public async Task<IActionResult> GetExpensesByPeriod([FromRoute] Guid periodId)
        {
            return Ok(await _expenseService.GetAsync(new GetExpenseQuery
            {
                PeriodId = periodId
            }));
        }

        [HttpGet("{periodName}")]
        public async Task<IActionResult> GetExpensesByPeriodName([FromRoute] string periodName)
        {
            return Ok(await _expenseService.GetAsync(new GetExpenseQuery
            {
                PeriodCode = periodName
            }));
        }
    }
}
