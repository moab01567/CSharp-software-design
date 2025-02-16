using ContactManager.AbstactClasses;
using ContactManager.Contacts;
using ContactManager.Interfaces;
using System.Data.SqlTypes;

namespace ContactManager.Houses;

public class HouseService : IBaseService<House>, IHouseOperators
{
	private AbstractRepository<House> _houseRepo;
	public HouseService(AbstractRepository<House> houseRepo) {
		_houseRepo = houseRepo;
	}

	public House CheckIfExist(int id, String massage)
	{
		House? house = _houseRepo.GetById(id);
		if (house == null) throw new SqlNullValueException(massage);
		return house;
	}
	public House Add(House entity)
	{
		return _houseRepo.Add(entity);
	}

	public void Delete(int id)
	{
		CheckIfExist(id, $"House with id {id} not found");
		_houseRepo.Delete(id);
	}
	public List<House> GetAll()
	{
		return _houseRepo.GetAll();
	}

	public House GetById(int id)
	{
		House house = CheckIfExist(id, $"House with id {id} not found");
		return house;
	}

	public House Update(House house)
	{
		House entity = CheckIfExist(house.Id, $"House with id {house.Id} not found");
		entity.Description = house.Description;
		entity.Address = house.Address;
		entity.Price = house.Price;
		entity.IsBuild = house.IsBuild;
		return _houseRepo.Update(entity);
	}

	//tatt i bruk operators her, bare for å dekke kompetanse kravene.
	//ikke sikker UI implmenterer disse, men da vil de bli testet :)
	public int CalculatePriceOfTowHouses(House house1, House house2)
	{
		return house1 + house2;
	}
	//tatt i bruk operators her, bare for å dekke kompetanse kravene.
	//ikke sikker UI implmenterer disse, men da vil de bli testet :)
	public bool ValidateIfSameHouse(House house1, House house2)
	{
		return house1 - house2;
	}
	//tatt i bruk operators her, bare for å dekke kompetanse kravene.
	//ikke sikker UI implmenterer disse, men da vil de bli testet :)
	public int CalculateThePriceOfxAmountOfHouse(House house, int amount)
	{
		return house * amount;	
	}
}
