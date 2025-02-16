using ContactManager.Database;
using ContactManager.Houses;

namespace ContactManager.Test.Operators;

public class OperatorHouseTest
{
	private HomeSalesDbContext _db = new();
	
	[OneTimeSetUp]
	public void SetUp()
	{

		new DataInit(null, new HouseRepository(_db), null).CreateFakeHouses();
	}

	[Test]
	public void CalculatePriceOfTowHousesTest()
	{
		//Arrange
		HouseService houseService = new(new HouseRepository(_db));
		List<House> houses = houseService.GetAll();
		House house1 = houses[0];
		House house2 = houses[1];

		//Act
		int valuePrice = houseService.CalculatePriceOfTowHouses(house1, house2);

		//Assert 
		Assert.That(house1.Price + house2.Price, Is.EqualTo(valuePrice));
	}

	[Test]
	public void ValidateIfSameHouseTest()
	{
		//Arrange
		HouseService houseService = new(new HouseRepository(_db));
		List<House> houses = houseService.GetAll();
		House house1 = houses[0];
		House house2 = houses[1];

		//Act
		bool isSameTrue = houseService.ValidateIfSameHouse(house1, house1);
		bool isSameFalse = houseService.ValidateIfSameHouse(house1, house2);

		//Assert 
		Assert.That(isSameTrue, Is.EqualTo(true));
		Assert.That(isSameFalse, Is.EqualTo(false));
	}

	[Test]
	public void CalculateThePriceOfxAmountOfHouseTest()
	{
		//Arrange
		HouseService houseService = new(new HouseRepository(_db));
		List<House> houses = houseService.GetAll();
		House house1 = houses[0];

		//Act
		int valuePrice = houseService.CalculateThePriceOfxAmountOfHouse(house1, 5);

		//Assert 
		Assert.That(house1.Price * 5, Is.EqualTo(valuePrice));
	}

}
