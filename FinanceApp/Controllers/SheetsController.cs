using FinanceApp.Data.Services;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceApp.Controllers
{
    public class SheetsController : Controller
    {
        private readonly IExpenseSheetsService _expenseSheetsService;

        public SheetsController(IExpenseSheetsService expenseSheetsService)
        {
            _expenseSheetsService = expenseSheetsService;
        }
        
        // View all expense sheets
        public async Task<IActionResult> Index()
        {
            var sheets = await _expenseSheetsService.GetAllExpenseSheetsAsync();

            return View(sheets);
        }

        // View specific expense sheet
        public async Task<IActionResult> Details(int id)
        {
            var sheet = await _expenseSheetsService.GetExpenseSheetByIdAsync(id);

            if (sheet == null)
                return NotFound();
            return View(sheet);
        }

        // Create empty expense sheet (view)
        public IActionResult Create()
        {
            return View();
        }

        // Create empty expense sheet (logic)
        [HttpPost]
        public async Task<IActionResult> Create(ExpenseSheet sheet)
        {
            if (ModelState.IsValid)
            {
                await _expenseSheetsService.AddExpenseSheetAsync(sheet);

                return RedirectToAction("Index");
            }
            return View(sheet);
        }

        // Add expense to existing expense sheet
        [HttpPost]
        public async Task<IActionResult> AddExpense(Expense expense, int sheetId)
        {
            if (ModelState.IsValid && expense != null)
            {
                await _expenseSheetsService.AddExpenseToSheetAsync(sheetId, expense);

                return RedirectToAction("Details", new { id = sheetId });
            }
            return RedirectToAction("Index"); // TODO: Redirect to Expense creation form
        }

        // Remove expense from existing expense sheet
        [HttpPost]
        public async Task<IActionResult> RemoveExpense(int expenseId, int sheetId)
        {
            await _expenseSheetsService.RemoveExpenseFromSheetAsync(sheetId, expenseId);
            return RedirectToAction("Details", new { id = sheetId });
        }

        // Remove expense sheet and all associated expenses
        [HttpPost]
        public async Task<IActionResult> Delete(int sheetId)
        {
            await _expenseSheetsService.RemoveExpenseSheetAsync(sheetId);
            return RedirectToAction("Index");
        }
    }
}
