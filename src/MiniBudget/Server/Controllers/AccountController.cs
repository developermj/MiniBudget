using Microsoft.AspNetCore.Mvc;
using MiniBudget.Server.Services;
using MiniBudget.Shared.Model;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MiniBudget.Server.Controllers;

public record AccountWithoutId(string Name, decimal Balance);

[Route("api/[controller]")]
[ApiController]
public class AccountController : ControllerBase
{
    private readonly IBudgetService budgetService;

    public AccountController(IBudgetService budgetService)
    {
        this.budgetService = budgetService;
    }

    // GET: api/<AccountController>
    [HttpGet]
    public IEnumerable<Account> Get() => budgetService.GetAllAccounts();

    // GET api/<AccountController>/5
    [HttpGet("{id}")]
    public Account? Get(int id) => budgetService.GetAccountById(id);

    [HttpGet("{id}/Categories")]
    public IEnumerable<Category> GetCategories(int id) => budgetService.GetCategoriesForAccount(id);

    // POST api/<AccountController>
    //[HttpPost]
    //public void Post([FromBody] string value)
    //{
    //}

    // PUT api/<AccountController>/5
    //[HttpPut("{id}")]
    //public void Put(int id, [FromBody] AccountWithoutId value)
    //{
    //    var account = new Account(id, value.Name, value.Balance);
    //    budgetService.UpsertAccount(account);
    //}

    // DELETE api/<AccountController>/5
    //[HttpDelete("{id}")]
    //public void Delete(int id)
    //{
    //}
}
