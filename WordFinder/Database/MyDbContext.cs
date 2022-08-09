using Microsoft.EntityFrameworkCore;
using WordFinder.Models;


namespace Database
{
	public class MyDbContext : DbContext
	{
		public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
		{
			Database.EnsureCreated();
		}

		public DbSet<DictionaryWord> Words {get; set;}
	}
}