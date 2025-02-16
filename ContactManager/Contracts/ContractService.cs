using ContactManager.AbstactClasses;
using ContactManager.Contacts;
using ContactManager.Customers;
using ContactManager.Houses;
using ContactManager.Interfaces;
using System.Data.SqlTypes;

namespace ContactManager.Contracts;

public class ContractService : IBaseService<Contract>
{
	private AbstractRepository<Contract> _contractRepo;
	private IBaseService<Customer> _customerService;
	private IBaseService<House> _houseService;

	public ContractService(AbstractRepository<Contract> contractRepo, IBaseService<Customer> customerService, IBaseService<House> houseService)
	{
		_contractRepo = contractRepo;
		_customerService = customerService;
		_houseService = houseService;
	}

	public Contract CheckIfExist(int id, string massage)
	{
		Contract? contract = _contractRepo.GetById(id);
		if (contract == null) throw new SqlNullValueException(massage);
		return contract;
	}
	public Contract Add(Contract contract)
	{
		Customer customer = _customerService.CheckIfExist(contract.CustomerId, $"Customer with Id {contract.CustomerId} Not Found");
		House house = _houseService.CheckIfExist(contract.HouseId, $"House with Id {contract.HouseId} Not Found");
		List<Contract> contacts = GetAll();
		contacts.ForEach(contract =>
		{
			if (contract.HouseId == house.Id && contract.CustomerId == customer.Id)
			{
				throw new SqlAlreadyFilledException("This contract between house and customer already exist ");
			}
		});
		
		return _contractRepo.Add(contract);
	}

	public void Delete(int id)
	{
		CheckIfExist(id, $"Contract with id {id} not found");
		_contractRepo.Delete(id);
	}

	public List<Contract> GetAll()
	{
		return _contractRepo.GetAll();
	}

	public Contract GetById(int id)
	{
		Contract contract = CheckIfExist(id, $"Contract with id {id} not found");
		return contract;
	}

	public Contract Update(Contract contract)
	{
		Contract entity = CheckIfExist(contract.Id, $"Contract with id {contract.Id} not found");
		entity.Paid = contract.Paid;

		return _contractRepo.Update(entity);
	}
}
