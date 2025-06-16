using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data.Services
{
    public class ExpenseSheetsService : IExpenseSheetsService
    {
        private readonly FinanceAppContext _context;

        public ExpenseSheetsService(FinanceAppContext context)
        {
            _context = context;
        }
        public async Task AddExpenseSheetAsync(ExpenseSheet expenseSheet)
        {
            _context.ExpensesSheets.Add(expenseSheet);
            await _context.SaveChangesAsync();
        }

        public async Task AddExpenseToSheetAsync(int sheetId, Expense expense)
        {
            expense.ExpenseSheetId = sheetId;

            _context.Expenses.Add(expense);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ExpenseSheet>> GetAllExpenseSheetsAsync()
        {
            return await _context.ExpensesSheets
                .Include(s => s.Expenses)
                .ToListAsync();
        }

        public async Task<ExpenseSheet?> GetExpenseSheetByIdAsync(int id)
        {
            return await _context.ExpensesSheets
                .Include(s => s.Expenses)
                .FirstOrDefaultAsync(s => s.Id == id);
        }

        public async Task RemoveExpenseFromSheetAsync(int sheetId, int expenseId)
        {
            var expense = await _context.Expenses.FirstOrDefaultAsync(e => e.Id == expenseId && e.ExpenseSheetId == sheetId);

            if (expense != null)
            {
                _context.Expenses.Remove(expense);
                await _context.SaveChangesAsync();
            }
        }

        public async Task RemoveExpenseSheetAsync(int expenseSheetId)
        {
            var sheet = await _context.ExpensesSheets.FindAsync(expenseSheetId);

            if (sheet != null)
            {
                _context.ExpensesSheets.Remove(sheet);
                await _context.SaveChangesAsync();
            }
        }
    }
}
