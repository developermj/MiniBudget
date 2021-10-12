using Microsoft.EntityFrameworkCore;

namespace MiniBudget.Server.Data;

public class MiniBudgetContext : DbContext
{
	public MiniBudgetContext(DbContextOptions<MiniBudgetContext> options) : base(options) { }

	public DbSet<Account> Accounts { get; set; }

	public DbSet<Category> Categories { get; set; }
}

public class Account
{
	public int AccountId { get; set; }

	public string Name { get; set; }

	public decimal Balance { get; set; }

	public List<Category> Categories { get; set; }
}

public class Category
{
	public int CategoryId { get; set; }

	public string Name { get; set; }

	public decimal Balance { get; set; }

	public int AccountId { get; set; }

	public Account Account { get; set; }
}
