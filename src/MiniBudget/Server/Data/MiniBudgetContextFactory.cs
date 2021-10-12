//using Microsoft.EntityFrameworkCore;
//using Microsoft.EntityFrameworkCore.Design;

//namespace MiniBudget.Server.Data
//{
//	public class MiniBudgetContextFactory : IDesignTimeDbContextFactory<MiniBudgetContext>
//	{
//		public MiniBudgetContext CreateDbContext(string[] args)
//		{
//			var configuration = new ConfigurationBuilder()
//				.SetBasePath(Directory.GetCurrentDirectory())
//				.AddJsonFile("appsettings.json")
//				.Build();

//			var optionsBuilder = new DbContextOptionsBuilder<MiniBudgetContext>();
//			optionsBuilder.UseSqlServer(configuration.GetConnectionString("MiniBudgetContext"));

//			return new MiniBudgetContext(optionsBuilder.Options);
//		}
//	}
//}
