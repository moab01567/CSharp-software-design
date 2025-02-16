using ContactManager.AbstactClasses;
using ContactManager.Contacts;
using ContactManager.Database;

namespace ContactManager.Customers;

public class CustomerRepository : AbstractRepository<Customer>
{
	public CustomerRepository(HomeSalesDbContext db) : base(db){}
}
