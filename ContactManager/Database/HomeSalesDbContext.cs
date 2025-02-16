using ContactManager.Contacts;
using ContactManager.Contracts;
using ContactManager.Houses;
using Microsoft.EntityFrameworkCore;

namespace ContactManager.Database;

public class HomeSalesDbContext : DbContext
{
	public DbSet<Customer> Customer => Set<Customer>();
	public DbSet<House> House => Set<House>();
	public DbSet<Contract> Contract => Set<Contract>();

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlite(@"Data Source = Resources\ContactManger.db");
	}
}
