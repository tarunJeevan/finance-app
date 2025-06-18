using FinanceApp.Models;

namespace FinanceApp.Models
{
    public class ExpenseSheetDetailsViewModel
    {
        public ExpenseSheet ExpenseSheet { get; set; } = null!;
        public Expense NewExpense { get; set; } = new Expense();
    }
}
