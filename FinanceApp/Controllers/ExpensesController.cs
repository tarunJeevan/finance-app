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

        public async Task<IActionResult> Delete()
        {
            var expenses = await _expensesService.GetAllExpensesAsync();
            return View(expenses);
        }

        public async Task<IActionResult> DeleteExpense(int id)
        {
            await _expensesService.RemoveExpenseAsync(id);
            return RedirectToAction("Index");
        }

        public IActionResult GetChartData()
        {
            var data = _expensesService.GetChartData();
            return Json(data);
        }
    }
}
