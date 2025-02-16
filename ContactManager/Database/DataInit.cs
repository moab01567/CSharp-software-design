using ContactManager.AbstactClasses;
using ContactManager.Contacts;
using ContactManager.Contracts;
using ContactManager.Houses;

namespace ContactManager.Database;

public class DataInit
{
	private Random _random = new();
	private AbstractRepository<Customer> _customerRepo;
	private AbstractRepository<House> _houseRepo;
	private AbstractRepository<Contract> _contractRepo;
	public DataInit(AbstractRepository<Customer> customerRepo, AbstractRepository<House> houseRepo, AbstractRepository<Contract> contractRepo)
	{
		_customerRepo = customerRepo;
		_houseRepo = houseRepo;
		_contractRepo = contractRepo;
	}

	public void GenerateData()
	{
		List<Customer> customersWithId = CreateFakeCustomers();
		List<House> housesWithId = CreateFakeHouses();
		List<Contract> contractsWithId = CreateFakeContracts(customersWithId, housesWithId);
	}

	public List<Contract> CreateFakeContracts(List<Customer> customersWithId, List<House> housesWithId)
	{
		List<Contract> contracts = new();
		foreach (House house in housesWithId)
		{
			contracts.Add(new Contract()
			{
				CustomerId = customersWithId[_random.Next(0, contracts.Count)].Id,
				HouseId = house.Id,
				Paid = _random.Next(0, house.Price + 1)
			});
		}
		Console.WriteLine("Contract Generated :)");
		List<Contract> contractsWithId = _contractRepo.AddRange(contracts);
		return contractsWithId;
	}

	public List<House> CreateFakeHouses()
	{
		List<House> houses = new();
		for (int i = 1; i < 10; i++)
		{
			houses.Add(new House()
			{
				Address = $"Address {i}",
				Description = $"Description {i}",
				IsBuild = _random.Next(0, 2) == 1,
				Price = _random.Next(1000000, 999999999)
			});
		}
		Console.WriteLine("Houses Generated :)");
		List<House> housesWithId = _houseRepo.AddRange(houses);
		return housesWithId;
	}

	public List<Customer> CreateFakeCustomers()
	{
		List<Customer> customers = new();
		for (int i = 1; i < 10; i++)
		{
			customers.Add(new Customer($"FirstName {i}", $"LastName {i}", $"PhoneNumber {i}")
			{
				Address = $"Address {i}",
				Email = $"Email {i}",
			});
		}
		Console.WriteLine("Customers Generated :)");
		List<Customer> customersWithId = _customerRepo.AddRange(customers);
		return customersWithId;
	}
}
