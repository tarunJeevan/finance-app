using FinanceApp.Data.Services;
using FinanceApp.Models;
using Microsoft.AspNetCore.Mvc;

namespace FinanceApp.Controllers
{
    public class ExpensesController : Controller
    {
        private readonly IExpensesService _expensesService;

        public ExpensesController(IExpensesService expensesService)
        {
            _expensesService = expensesService;
        }

        public async Task<IActionResult> Index()
        {
            var expenses = await _expensesService.GetAllExpensesAsync();
            return View(expenses);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Expense expense)
        {
            if (ModelState.IsValid)
            {
                await _expensesService.AddExpenseAsync(expense);

                return RedirectToAction("Index");
            }
            // Do nothing and redirect to same page if request is invalid
            return View(expense);
        }
    }
}
