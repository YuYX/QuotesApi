using Microsoft.EntityFrameworkCore;
using QuotesApi.Models;

namespace QuotesApi.Data
{
	public class QuotesDbContext : DbContext
	{ 
        public DbSet<Quote> Quotes { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			// This is for Local MSSQL database
			//optionsBuilder.UseSqlServer(@"Server=(localdb)\MSSQLLocalDB;Initial Catalog=QuotesDb;");

			// This is for Azure Cloud SQL database
			optionsBuilder.UseSqlServer(@"Server=tcp:quotesdbserveryyx.database.windows.net,1433;Initial Catalog=QuotesDb;Persist Security Info=False;User ID=yuyongxue;Password=$$12345678Aa;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
		}
	}
}
