using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data.Services
{
    public class ExpensesService : IExpensesService
    {
        private readonly FinanceAppContext _context;

        public ExpensesService(FinanceAppContext context) 
        {
            _context = context;
        }

        public async Task AddExpenseAsync(Expense expense)
        {
            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Expense>> GetAllExpensesAsync()
        {
            var expenses = await _context.Expenses.ToListAsync();
            return expenses;
        }

        public IQueryable GetChartData()
        {
            // Filter expense data into readable JSON object where expenses are aggregated into and grouped by category
            var data = _context.Expenses
                .GroupBy(ex => ex.Category)
                .Select(g => new
                {
                    Category = g.Key,
                    Total = g.Sum(e => e.Amount)
                });
            return data;
        }

        public async Task RemoveExpenseAsync(int expenseId)
        {
            // Retrieve the expense with the matching Id
            var expense = await _context.Expenses.FindAsync(expenseId);

            if (expense != null)
            {
                _context.Expenses.Remove(expense!);
                await _context.SaveChangesAsync();
            }
        }
    }
}
