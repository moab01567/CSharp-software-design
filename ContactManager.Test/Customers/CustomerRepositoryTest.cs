
using ContactManager.Contacts;
using ContactManager.Contracts;
using ContactManager.Customers;
using ContactManager.Database;
using ContactManager.Houses;

namespace ContactManager.Test.Customers;

public class CustomerRepositoryTest
{

	[OneTimeSetUp]
	public void SetUp()
	{
		HomeSalesDbContext db = new HomeSalesDbContext();
		new DataInit(new CustomerRepository(db), null , null).CreateFakeCustomers();
	}

	[Test]
	public void DeleteCsutomerFromDatabseTest()
	{
		//Arrange
		CustomerRepository customerRepo = new (new HomeSalesDbContext());
		List<Customer> customers = customerRepo.GetAll();
		
		//Act
		customerRepo.Delete(customers[0].Id);

		//Assert
		Assert.That(customerRepo.GetAll().Count, Is.EqualTo(customers.Count - 1));
	}

	[Test]
	public void AddCsutomerToDatabaseTest()
	{
		//Arrange
		CustomerRepository customerRepo = new(new HomeSalesDbContext());

		//Act
		Customer customer = customerRepo.Add(new Customer("test", "test", "test")
		{
			Address = "test",
			Email = "test",
		});
		Customer? addedCustomer = customerRepo.GetById(customer.Id);

		//Assert
		Assert.That("test", Is.EqualTo(addedCustomer.FirstName));
	}


}
