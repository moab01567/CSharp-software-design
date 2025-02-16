
using ContactManager.Contacts;
using ContactManager.Contacts.Contact;
using ContactManager.Contracts;
using ContactManager.Customers;
using ContactManager.Database;
using ContactManager.Interfaces;
using System.Data.SqlTypes;

namespace ContactManager.Test.Intergrastion;
public class CustomerServiceIntegrationTest
{

	private HomeSalesDbContext _db = new();


	[Test]
	public void AddTest()
	{
		//Arrange
		CustomerService customerService = new CustomerService(new CustomerRepository(_db));

		//Act
		Customer customer = customerService.Add(new Customer("CustomerService", "CustomerService", "CustomerService"));

		//Assert
		Assert.That(customerService.GetById(customer.Id).Equals(customer), Is.True);
	}

	[Test]
	public void DeleteTest()
	{
		//Arrange
		CustomerService customerService = new CustomerService(new CustomerRepository(_db));
		Customer customer = customerService.Add(new Customer("CustomerService", "CustomerService", "CustomerService"));

		//Act
		customerService.Delete(customer.Id);

		//Assert
		Assert.Throws<SqlNullValueException>(() => customerService.GetById(customer.Id));
	}
	[Test]
	public void GetAllTest()
	{
		//Arrange
		CustomerService customerService = new CustomerService(new CustomerRepository(_db));
		List<Customer> customers1 = customerService.GetAll();
		Customer customer = customerService.Add(new Customer("CustomerService", "CustomerService", "CustomerService"));
		
		//Act
		List<Customer> customers2 = customerService.GetAll();

		//Assert
		Assert.That(customers1.Count + 1, Is.EqualTo(customers2.Count));
	}
	[Test]
	public void UpdateTest()
	{
		//Arrange
		CustomerService customerService = new CustomerService(new CustomerRepository(_db));
		Customer customer = customerService.Add(new Customer("CustomerService", "CustomerService", "CustomerService"));

		//Act
		customer.FirstName = "new FirstName";
		Customer updatedCustomer = customerService.Update(customer);
		

		//Assert
		Assert.That(updatedCustomer.FirstName, Is.EqualTo("new FirstName"));
	}
}
