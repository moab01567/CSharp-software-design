
using ContactManager.AbstactClasses;
using ContactManager.Interfaces;
using ContactManager.UtilUI;

namespace ContactManager.Houses;

public class HouseUI : AbstractUI
{
	private IBaseService<House> _houseService;
	protected override string _header { get; } = "  _   _                            __  __                             \r\n | | | | ___  _   _ ___  ___      |  \\/  | __ _ _ __   __ _  ___ _ __ \r\n | |_| |/ _ \\| | | / __|/ _ \\_____| |\\/| |/ _` | '_ \\ / _` |/ _ \\ '__|\r\n |  _  | (_) | |_| \\__ \\  __/_____| |  | | (_| | | | | (_| |  __/ |   \r\n |_| |_|\\___/ \\__,_|___/\\___|     |_|  |_|\\__,_|_| |_|\\__, |\\___|_|   \r\n                                                      |___/           ";
	protected override string _menuName { get; } = "House menu";
	protected override List<string> _menuOptions { get; } = new List<string>
	{
		"Press 1 to View all Houses",
		"Press 2 to Add a Houses",
		"Press 3 to Update a Houses",
		"Press 4 to Get a Houses By Id",
		"Press 5 to Delete a Houses",
		"Press b to Go back to Main Manu"
	};

	public HouseUI(IBaseService<House> houseService)
	{
		_houseService = houseService;
	}

	public override void Run()
	{
		bool quit = false;
		DisplayMessage displayMassage = new("", MassageType.Info);

		while (!quit)
		{
			base.DisplayUI(displayMassage);

			switch (UIDisplayhelper.DisplayInputFiled())
			{
				case "1":
					displayMassage = ViewAllhouses();
					break;
				case "2":
					displayMassage = AddHouse();
					break;
				case "3":
					displayMassage = UpdateHouse();
					break;
				case "4":
					displayMassage = GetHouseById();
					break;
				case "5":
					displayMassage = DeleteHouse();
					break;
				case "b":
					quit = true;
					break;
				default:
					break;
			}
		}
	}

	private DisplayMessage GetHouseById()
	{
		try
		{
			string id = UIDisplayhelper.DisplayInputFiled("House Id: ");
			int houseId = UITypeValidator.ValidateInt(id, "Not Valid Id");
			House house = _houseService.GetById(houseId);
			return new DisplayMessage($"{house}", MassageType.Info);
		}
		catch (Exception ex)
		{
			return new DisplayMessage(ex.Message, MassageType.Failed);
		}
	}

	private DisplayMessage DeleteHouse()
	{
		try
		{
			string id = UIDisplayhelper.DisplayInputFiled("House Id: ");
			int houseId = UITypeValidator.ValidateInt(id, "Not Valid Id");
			_houseService.Delete(houseId);
			return new DisplayMessage($"Deleted with id {houseId}", MassageType.Success);
		}
		catch (Exception ex)
		{
			return new DisplayMessage(ex.Message, MassageType.Failed);
		}
	}

	private DisplayMessage ViewAllhouses()
	{
		try
		{
			string massage = string.Empty;
			_houseService.GetAll().ForEach(house => massage = $"{massage} {house}\n");
			return new DisplayMessage(massage, MassageType.Info);
		}
		catch (Exception ex)
		{
			return new DisplayMessage(ex.Message, MassageType.Failed);
		}
	}
	private DisplayMessage AddHouse()
	{
		try
		{
			string address = UIDisplayhelper.DisplayInputFiled("(Required) Address: ");
			address = UITypeValidator.ValidateString(address, "Not Valid Address");
			string price = UIDisplayhelper.DisplayInputFiled("(Required) Price: ");
			int intPrice = UITypeValidator.ValidateInt(price, "Not Valid Price");
			string? description = UIDisplayhelper.DisplayInputFiled("(Optional) Description: ");
			description = UITypeValidator.ValidateSetNullIfEmty(description);
			string isBuild = UIDisplayhelper.DisplayInputFiled("(Defule no) <true,false> Is Build: ").ToLower();
			bool boolIsBuild = UITypeValidator.ValidateYesOrNo(isBuild);


			House house = _houseService.Add(new House()
			{
				Address = address,
				Price = intPrice,
				Description = description,
				IsBuild = boolIsBuild
			});
			return new DisplayMessage($"Created with Id {house.Id}", MassageType.Success);
		}
		catch (Exception ex)
		{
			return new DisplayMessage($"{ex.Message}", MassageType.Failed);
		}
	}
	private DisplayMessage UpdateHouse()
	{
		try
		{
			string id = UIDisplayhelper.DisplayInputFiled("(Required) House Id: ");
			int intId = UITypeValidator.ValidateInt(id, "Not Valid Id");
			string address = UIDisplayhelper.DisplayInputFiled("(Required) Address: ");
			address = UITypeValidator.ValidateString(address, "Not Valid Address");
			string price = UIDisplayhelper.DisplayInputFiled("(Required) Price: ");
			int intPrice = UITypeValidator.ValidateInt(price, "Not Valid Price");
			string? description = UIDisplayhelper.DisplayInputFiled("(Optional) Description: ");
			description = UITypeValidator.ValidateSetNullIfEmty(description);
			string isBuild = UIDisplayhelper.DisplayInputFiled("(Defule no) <true,false> Is Build: ").ToLower();
			bool boolIsBuild = UITypeValidator.ValidateYesOrNo(isBuild);

			House house = _houseService.Update(new House()
			{
				Id = intId,
				Address = address,
				Price = intPrice,
				Description = description,
				IsBuild = boolIsBuild,
			});
			return new DisplayMessage($"Updated with Id {house.Id}", MassageType.Success);
		}
		catch (Exception ex)
		{
			return new DisplayMessage($"{ex.Message}", MassageType.Failed);
		}
	}
}
