using FinanceApp.Models;

namespace FinanceApp.Data.Services
{
    public interface IExpenseSheetsService
    {
        Task<IEnumerable<ExpenseSheet>> GetAllExpenseSheetsAsync();
        Task<ExpenseSheet?> GetExpenseSheetByIdAsync(int id);
        Task AddExpenseSheetAsync(ExpenseSheet expenseSheet);
        Task RemoveExpenseSheetAsync(int expenseSheetId);
        Task AddExpenseToSheetAsync(int sheetId, Expense expense);
        Task RemoveExpenseFromSheetAsync(int sheetId, int expenseId);
    }
}
