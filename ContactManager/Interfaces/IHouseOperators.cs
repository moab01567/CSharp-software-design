using ContactManager.Houses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContactManager.Interfaces;

public interface IHouseOperators
{
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
