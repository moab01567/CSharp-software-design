using ContactManager.AbstactClasses;
using ContactManager.Customers;
using ContactManager.Interfaces;
using System.Data.SqlTypes;

namespace ContactManager.Contacts.Contact;
public class CustomerService : IBaseService<Customer>
{
	private AbstractRepository<Customer> _customerRepo;
	
	public CustomerService(AbstractRepository<Customer> customerRepo)
	{
		_customerRepo = customerRepo;
	}
	
	public Customer CheckIfExist(int id, String massage)
	{
		Customer? customer = _customerRepo.GetById(id);
		if (customer == null) throw new SqlNullValueException(massage);
		return customer;
	}
	public Customer Add(Customer customer)
	{
		customer.MakeEmptyStringsToNull();
		return _customerRepo.Add(customer);
	}
	public Customer Update(Customer customer)
	{
		Customer customerFromDb = CheckIfExist(customer.Id, $"Customer with id {customer.Id} not found");
		customer.MakeEmptyStringsToNull();
		customerFromDb.Email = customer.Email;
		customerFromDb.FirstName = customer.FirstName;	
		customerFromDb.LastName = customer.LastName;
		customerFromDb.PhoneNumber = customer.PhoneNumber;
		customerFromDb.Address = customer.Address;
		return _customerRepo.Update(customerFromDb);
	}
	public void Delete(int id)
	{
		CheckIfExist(id, $"Customer with id {id} not found");
		_customerRepo.Delete(id);
	}
	public Customer GetById(int id)
	{
		Customer customer = CheckIfExist(id, $"Customer with id {id} not found");
		return customer;
	}
	public List<Customer> GetAll()
	{
		return _customerRepo.GetAll();
	}
}