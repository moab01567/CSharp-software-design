
using ContactManager.AbstactClasses;
using ContactManager.Contacts.Contact;
using ContactManager.Contacts;
using ContactManager.Contracts;
using ContactManager.Customers;
using ContactManager.Database;
using ContactManager.Houses;
using ContactManager.Interfaces;

namespace ContactManager;

public class Application
{

	public void Setup()
	{
		HomeSalesDbContext db = new();
		AbstractRepository<Customer> customerRepo = new CustomerRepository(db);
		AbstractRepository<House> houseRepo = new HouseRepository(db);
		AbstractRepository<Contract> contractRepo = new ContractRepository(db);

		DataInit databaseInit = new(customerRepo, houseRepo, contractRepo);
		databaseInit.GenerateData();

		IBaseService<Customer> customerService = new CustomerService(customerRepo);
		IBaseService<House> houseService = new HouseService(houseRepo);
		IBaseService<Contract> contractService = new ContractService(contractRepo, customerService, houseService);

		AbstractUI customerUI = new CustomerUI(customerService);
		AbstractUI houseUI = new HouseUI(houseService);
		AbstractUI contractUI = new ContractUI(contractService);
		AbstractUI ui = new RealEstateMangerUI(customerUI, houseUI, contractUI);
		ui.Run();
	}


}
