using MiniBudget.Shared.Model;

namespace MiniBudget.Server.Services;

public class InMemoryBudgetService : IBudgetService
{
    private static readonly List<Account> TempAccounts = new()
    {
        new Account(1, "Checking", 1000),
        new Account(2, "Savings", 0)
    };

    private static readonly List<Category> TempCategories = new()
    {
        new Category(1, 1, "Food", 1000)
    };

    public IEnumerable<Account> GetAllAccounts() => TempAccounts;

    public Account? GetAccountById(int id) => TempAccounts.Find(a => a.Id == id);

    public void UpsertAccount(Account account)
    {
        var idx = TempAccounts.FindIndex(x => x.Id == account.Id);
        if (idx == -1)
        {
            TempAccounts.Add(account);
        } else
        {
            TempAccounts[idx] = account;
        }
    }

    public IEnumerable<Category> GetCategoriesForAccount(int id) => TempCategories.FindAll(c => c.AccountId == id);

    public Category? GetCategoryById(int id) => TempCategories.Find(c => c.Id == id);

	public void AlterCategoryBalance(int id, BalanceAlter value)
	{
        var idx = TempCategories.FindIndex(c => c.Id == id);
        if (idx > -1)
        {
            var category = TempCategories[idx];
            if (category is not null)
            {
                switch (value.AlterType)
                {
                    case AlterTypes.Add:
                        category = category with { Balance = category.Balance + value.Amount };
                        break;
                    case AlterTypes.Reduce:
                        category = category with { Balance = category.Balance - value.Amount };
                        break;
                    case AlterTypes.Set:
                        category = category with { Balance = value.Amount };
                        break;
                }
                TempCategories[idx] = category;

                var accountIdx = TempAccounts.FindIndex(a => a.Id == category.AccountId);
                if (accountIdx > -1)
				{
                    var account = TempAccounts[accountIdx];
                    if (account is not null)
					{
                        account = account with { Balance = TempCategories.Where(c => c.AccountId == category.AccountId).Sum(c => c.Balance) };
                        TempAccounts[idx] = account;
					}
				}
            }
        }
	}
}
