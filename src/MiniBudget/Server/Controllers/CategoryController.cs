using Microsoft.AspNetCore.Mvc;
using MiniBudget.Server.Services;
using MiniBudget.Shared.Model;

namespace MiniBudget.Server.Controllers
{
	[Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IBudgetService budgetService;

        public CategoryController(IBudgetService budgetService)
        {
            this.budgetService = budgetService;
        }
        // GET: api/<CategoryController>
        //[HttpGet]
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<CategoryController>/5
        [HttpGet("{id}")]
        public Category? Get(int id) => budgetService.GetCategoryById(id);

        // POST api/<CategoryController>
        //[HttpPost]
        //public void Post([FromBody] string value)
        //{
        //}

        // PUT api/<CategoryController>/5
        [HttpPut("{id}/AlterBalance")]
        public void Put(int id, [FromBody] BalanceAlter value)
        {
            budgetService.AlterCategoryBalance(id, value);
        }

        // DELETE api/<CategoryController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{
        //}
    }
}
