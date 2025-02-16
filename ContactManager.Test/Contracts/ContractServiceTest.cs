
using ContactManager.Contacts.Contact;
using ContactManager.Contracts;
using ContactManager.Customers;
using ContactManager.Database;
using ContactManager.Houses;
using System.Data.SqlTypes;

namespace ContactManager.Test.Contracts;

public class ContractServiceTest
{
	private HomeSalesDbContext _db = new ();

	[OneTimeSetUp]
	public void SetUp()
	{
		new DataInit(new CustomerRepository(_db), new HouseRepository(_db) , new ContractRepository(_db)).GenerateData();
	}
	[Test]
	public void DeleteContractTest()
	{
		//Arrange
		ContractService contractService = new ContractService(new ContractRepository(_db));
		List<Contract>  contracts = contractService.GetAll();
		Contract contract = contracts[0];

		//Act
		contractService.Delete(contract.Id);

		//Assart
		Assert.Throws<SqlNullValueException>(() => contractService.GetById(contract.Id));
	}
	public void DeleteCustomerToCheckIfContractGetsDeleted()
	{
		//Arrange
		ContractService contractService = new ContractService(new ContractRepository(_db));
		CustomerService customerService = new CustomerService(new CustomerRepository(_db));
		List<Contract> contracts = contractService.GetAll();
		Contract contract = contracts[0];

		//Act
		customerService.Delete(contract.CustomerId);

		//Assart
		Assert.Throws<SqlNullValueException>(() => contractService.GetById(contract.Id));
	}
}
