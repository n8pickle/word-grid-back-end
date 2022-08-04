using Microsoft.EntityFrameworkCore;
using WordFinder.Models;


namespace Database
{
	public class MyDbContext : DbContext
	{
		protected readonly IConfiguration Configuration;
		public MyDbContext(IConfiguration configuration)
		{
			Configuration = configuration;
		}

		protected override void OnConfiguring(DbContextOptionsBuilder options)
    	{
        	var connectionString = Configuration["DbConnectionString"];
        	options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    	}

		public DbSet<DictionaryWord> Words { get; set; }

	}
}