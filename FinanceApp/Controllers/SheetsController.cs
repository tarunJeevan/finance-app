using FinanceApp.Data.Services;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Controllers
{
    public class SheetsController : Controller
    {
        private readonly IExpenseSheetsService _expenseSheetsService;

        public SheetsController(IExpenseSheetsService expenseSheetsService)
        {
            _expenseSheetsService = expenseSheetsService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExpenseSheet>> GetExpenseSheet(int id)
        {
            var sheet = await _expenseSheetsService.GetExpenseSheetByIdAsync(id);
        }
    }
}
