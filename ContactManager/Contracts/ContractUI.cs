using ContactManager.AbstactClasses;
using ContactManager.Interfaces;
using ContactManager.UtilUI;

namespace ContactManager.Contracts;

public class ContractUI : AbstractUI
{
	private IBaseService<Contract> _contractService;
	protected override string _header { get; } = "   ____            _                  _        __  __                             \r\n  / ___|___  _ __ | |_ _ __ __ _  ___| |_     |  \\/  | __ _ _ __   __ _  ___ _ __ \r\n | |   / _ \\| '_ \\| __| '__/ _` |/ __| __|____| |\\/| |/ _` | '_ \\ / _` |/ _ \\ '__|\r\n | |__| (_) | | | | |_| | | (_| | (__| ||_____| |  | | (_| | | | | (_| |  __/ |   \r\n  \\____\\___/|_| |_|\\__|_|  \\__,_|\\___|\\__|    |_|  |_|\\__,_|_| |_|\\__, |\\___|_|   \r\n                                                                  |___/           ";
	protected override string _menuName { get; } = "Contract menu";
	protected override List<string> _menuOptions { get; } = new List<string>
	{
		"Press 1 to View all Contract",
		"Press 2 to Add a Contract",
		"Press 3 to Update a Contract",
		"Press 4 to Get a Contract",
		"Press 5 to Delete a Contract",
		"Press b to Go back to Main Manu"
	};
	public ContractUI(IBaseService<Contract> contractService)
	{
		_contractService = contractService;
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
					displayMassage = ViewAllContracts();
					break;
				case "2":
					displayMassage = AddContract();
					break;
				case "3":
					displayMassage = UpdateContract();
					break;
				case "4":
					displayMassage = GetContractById();
					break;
				case "5":
					displayMassage = DeleteContract();
					break;
				case "b":
					quit = true;
					break;
				default:
					break;
			}
		}
	}

	private DisplayMessage DeleteContract()
	{
		try
		{
			string id = UIDisplayhelper.DisplayInputFiled("Contract Id: ");
			int ContractId = UITypeValidator.ValidateInt(id, "Not Valid Id");
			_contractService.Delete(ContractId);
			return new DisplayMessage($"Deleted with id {ContractId}", MassageType.Success);
		}
		catch (Exception ex)
		{
			return new DisplayMessage(ex.Message, MassageType.Failed);
		}
	}
	private DisplayMessage GetContractById()
	{
		try
		{
			string id = UIDisplayhelper.DisplayInputFiled("Contract Id: ");
			int contractId = UITypeValidator.ValidateInt(id, "Not Valid Id");
			Contract contract = _contractService.GetById(contractId);
			return new DisplayMessage($"{contract}", MassageType.Info);
		}
		catch (Exception ex)
		{
			return new DisplayMessage(ex.Message, MassageType.Failed);
		}
	}

	private DisplayMessage UpdateContract()
	{
		try
		{
			string id = UIDisplayhelper.DisplayInputFiled("(Required) Contract Id: ");
			int intId = UITypeValidator.ValidateInt(id, "Not Valid Id");
			string amout = UIDisplayhelper.DisplayInputFiled("(Required) Amount Paid: ");
			int intAmout = UITypeValidator.ValidateInt(amout, "Not Valid Amount");


			Contract contract = _contractService.Update(new Contract()
			{
				Id = intId,
				Paid = intAmout
			});
			return new DisplayMessage($"Updated with Id {contract.Id}", MassageType.Success);
		}
		catch (Exception ex)
		{
			return new DisplayMessage($"{ex.Message}", MassageType.Failed);
		}
	}

	private DisplayMessage AddContract()
	{
		try
		{
			string customerId = UIDisplayhelper.DisplayInputFiled("(Required) Customer Id: ");
			int intCustomerId = UITypeValidator.ValidateInt(customerId, "Not Valid Id");
			string houseId = UIDisplayhelper.DisplayInputFiled("(Required) House Id: ");
			int inthouseId = UITypeValidator.ValidateInt(houseId, "Not Valid Id");
			string amout = UIDisplayhelper.DisplayInputFiled("(Required) Amount Paid: ");
			int intAmout = UITypeValidator.ValidateInt(amout, "Not Valid Amount");

			Contract contract = _contractService.Add(new Contract()
			{
				CustomerId = intCustomerId,
				Paid = intAmout,
				HouseId = inthouseId
			});
			return new DisplayMessage($"Updated with Id {contract.Id}", MassageType.Success);
		}
		catch (Exception ex)
		{
			return new DisplayMessage($"{ex.Message}", MassageType.Failed);
		}
	}

	private DisplayMessage ViewAllContracts()
	{
		try
		{
			string massage = string.Empty;
			_contractService.GetAll().ForEach(contract => massage = $"{massage} {contract}\n");
			return new DisplayMessage(massage, MassageType.Info);
		}
		catch (Exception ex)
		{
			return new DisplayMessage(ex.Message, MassageType.Failed);
		}
	}
}
