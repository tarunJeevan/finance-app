using FinanceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace FinanceApp.Data
{
    public class FinanceAppContext : DbContext
    {
        private readonly DbContext _context;
        public FinanceAppContext(DbContextOptions<FinanceAppContext> options) : base(options) { }

        DbSet<Expense> Expenses { get; set; }
    }
}
