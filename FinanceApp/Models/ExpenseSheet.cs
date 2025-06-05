using System.ComponentModel.DataAnnotations;

namespace FinanceApp.Models
{
    public class ExpenseSheet
    {
        public int Id { get; set; } // Primary Key

        // Set data constraints using data annotations
        [Required(ErrorMessage = "Expense sheet title required")]
        public string Title { get; set; } = null!;

        [Required(ErrorMessage = "Expense sheet description required")]
        public string Description { get; set; } = null!;

        [Required(ErrorMessage = "Please set start date")]
        public DateTime StartDate { get; set; }
        [Required(ErrorMessage = "Please set end date")]
        public DateTime EndDate { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public ICollection<Expense> Expenses { get; set; } = new List<Expense>();
    }
}
