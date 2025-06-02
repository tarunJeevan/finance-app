using System.ComponentModel.DataAnnotations;

namespace FinanceApp.Models
{
    public class Expense
    {
        public int Id { get; set; }

        // Set data constraints using data annotations
        [Required(ErrorMessage = "Expense description required")]
        public string Description { get; set; } = null!;
        [Required(ErrorMessage = "Missing amount in expense")]
        [Range(0.01, double.MaxValue, ErrorMessage = "Amount must be positive")]
        public double Amount { get; set; }
        [Required(ErrorMessage = "Expense category must be set")]
        public string Category { get; set; } = null!; // Replace with Enum?

        public DateTime Date { get; set; } = DateTime.Now;
    }
}
