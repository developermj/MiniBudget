using MiniBudget.Server.Data;
using MiniBudget.Shared.Model;
using Model = MiniBudget.Shared.Model;

namespace MiniBudget.Server.Services;

public class SqlBudgetService : IBudgetService
{
	private readonly MiniBudgetContext context;

	public SqlBudgetService(MiniBudgetContext context)
	{
		this.context = context;
	}

	public void AlterCategoryBalance(int id, BalanceAlter value)
	{
        var category = context.Categories.Find(id);
        category.Balance = value.AlterType switch
        {
            AlterTypes.Set => value.Amount,
            AlterTypes.Add => category.Balance + value.Amount,
            AlterTypes.Reduce => category.Balance - value.Amount,
            _ => throw new ArgumentOutOfRangeException(nameof(value))
        };
		var account = context.Accounts.Find(category.AccountId);
		context.SaveChanges();
		account.Balance = context.Categories.Where(c => c.AccountId == account.AccountId).Sum(c => c.Balance);
        context.SaveChanges();
	}

	public Model.Account? GetAccountById(int id)
	{
        var db = context.Accounts.Find(id);
        return new Model.Account(db.AccountId, db.Name, db.Balance);
	}

	public IEnumerable<Model.Account> GetAllAccounts()
	{
        return context.Accounts.Select(a => new Model.Account(a.AccountId, a.Name, a.Balance));
	}

	public IEnumerable<Model.Category> GetCategoriesForAccount(int id)
	{
		return context.Categories.Where(c => c.AccountId == id).Select(c => new Model.Category(c.CategoryId, c.AccountId, c.Name, c.Balance));
	}

	public Model.Category? GetCategoryById(int id)
	{
        var db = context.Categories.Find(id);
        return new Model.Category(db.CategoryId, db.AccountId, db.Name, db.Balance);
	}
}
