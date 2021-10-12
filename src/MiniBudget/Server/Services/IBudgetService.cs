using MiniBudget.Shared.Model;

namespace MiniBudget.Server.Services;

public interface IBudgetService
{
    IEnumerable<Account> GetAllAccounts();
    Account? GetAccountById(int id);
    //void UpsertAccount(Account account);
    IEnumerable<Category> GetCategoriesForAccount(int id);
    Category? GetCategoryById(int id);
	void AlterCategoryBalance(int id, BalanceAlter value);
}
