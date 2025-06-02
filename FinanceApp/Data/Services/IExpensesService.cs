using FinanceApp.Models;

namespace FinanceApp.Data.Services
{
    public interface IExpensesService
    {
        Task<IEnumerable<Expense>> GetAllExpensesAsync();

        Task AddExpenseAsync(Expense expense);
    }
}
