using FinanceApp.Models;

namespace FinanceApp.Data.Services
{
    public interface IExpensesService
    {
        Task<IEnumerable<Expense>> GetAllExpensesAsync();
        Task AddExpenseAsync(Expense expense);
        Task RemoveExpenseAsync(int expenseId);
        IQueryable GetChartData();
    }
}
