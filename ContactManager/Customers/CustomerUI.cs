using ContactManager.AbstactClasses;
using ContactManager.Contacts;
using ContactManager.Interfaces;
using ContactManager.UtilUI;


namespace ContactManager.Customers;

public class CustomerUI : AbstractUI
{
	private IBaseService<Customer> _customerService;
	protected override string _header { get; } = "   ____          _                                 __  __                             \r\n  / ___|   _ ___| |_ ___  _ __ ___   ___ _ __     |  \\/  | __ _ _ __   __ _  ___ _ __ \r\n | |  | | | / __| __/ _ \\| '_ ` _ \\ / _ \\ '__|____| |\\/| |/ _` | '_ \\ / _` |/ _ \\ '__|\r\n | |__| |_| \\__ \\ || (_) | | | | | |  __/ | |_____| |  | | (_| | | | | (_| |  __/ |   \r\n  \\____\\__,_|___/\\__\\___/|_| |_| |_|\\___|_|       |_|  |_|\\__,_|_| |_|\\__, |\\___|_|   \r\n                                                                      |___/           ";
	protected override string _menuName { get; } = "Customer menu";
	protected override List<string> _menuOptions { get; } = new List<string>
	{
		"Press 1 to View All Customers",
		"Press 2 to Add a Customer",
		"Press 3 to Update a Customer",
		"Press 4 to Get Customer By Id",
		"Press 5 to Delete a Customer",
		"Press b to Go back to Main Manu"
	};

	public CustomerUI(IBaseService<Customer> customerService)
	{
		_customerService = customerService;
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
					displayMassage = ViewAllCstomers();
					break;
				case "2":
					displayMassage = AddCustomer();
					break;
				case "3":
					displayMassage = UpdateCustomer();
					break;
				case "4":
					displayMassage = GetById();
					break;
				case "5":
					displayMassage = DeleteCustomer();
					break;
				case "b":
					quit = true;
					break;
				default:
					break;
			}
		}
	}

	private DisplayMessage GetById()
	{
		try
		{
			string id = UIDisplayhelper.DisplayInputFiled("Customer Id: ");
			Customer customer = _customerService.GetById(UITypeValidator.ValidateInt(id, "Not Valid Id"));
			return new DisplayMessage($"{customer}", MassageType.Info);
		}
		catch (Exception ex)
		{
			return new DisplayMessage(ex.Message, MassageType.Failed);
		}
	}

	private DisplayMessage DeleteCustomer()
	{
		try
		{
			string id = UIDisplayhelper.DisplayInputFiled("Customer Id: ");
			_customerService.Delete(UITypeValidator.ValidateInt(id, "Not Valid Id"));
			return new DisplayMessage($"Deleted with id {id}", MassageType.Success);
		}
		catch (Exception ex)
		{
			return new DisplayMessage(ex.Message, MassageType.Failed);
		}
	}

	private DisplayMessage ViewAllCstomers()
	{
		try
		{
			string massage = string.Empty;
			_customerService.GetAll().ForEach(customer => massage = $"{massage} {customer}\n");
			return new DisplayMessage(massage, MassageType.Info);
		}
		catch (Exception ex)
		{
			return new DisplayMessage(ex.Message, MassageType.Failed);
		}
	}
	private DisplayMessage AddCustomer()
	{
		try
		{
			string firstName = UIDisplayhelper.DisplayInputFiled("(Required) First Name: ");
			firstName = UITypeValidator.ValidateString(firstName, "Not Valid First Name");
			string lastName = UIDisplayhelper.DisplayInputFiled("(Required) Last Name: ");
			lastName = UITypeValidator.ValidateString(lastName, "Not Valid Last Name");
			string phoneNumber = UIDisplayhelper.DisplayInputFiled("(Required) Phone Number: ");
			phoneNumber = UITypeValidator.ValidateString(phoneNumber, "Not Valid Phone NUmber");
			string? address = UIDisplayhelper.DisplayInputFiled("(Optional) Address: ");
			address = UITypeValidator.ValidateSetNullIfEmty(address);
			string? email = UIDisplayhelper.DisplayInputFiled("(Optional) Email: ");
			email = UITypeValidator.ValidateSetNullIfEmty(email);
			Customer customer = _customerService.Add(new Customer(firstName, lastName, phoneNumber, email, address));
			return new DisplayMessage($"Created with Id {customer.Id}", MassageType.Success);
		}
		catch (Exception ex)
		{
			return new DisplayMessage($"{ex.Message}", MassageType.Failed);
		}
	}
	private DisplayMessage UpdateCustomer()
	{
		try
		{
			string id = UIDisplayhelper.DisplayInputFiled("(Required) Customer Id: ");
			int customerId = UITypeValidator.ValidateInt(id, "Not Valid Id");
			string firstName = UIDisplayhelper.DisplayInputFiled("(Required) First Name: ");
			firstName = UITypeValidator.ValidateString(firstName, "Not Valid First Name");
			string lastName = UIDisplayhelper.DisplayInputFiled("(Required) Last Name: ");
			lastName = UITypeValidator.ValidateString(lastName, "Not Valid Last Name");
			string phoneNumber = UIDisplayhelper.DisplayInputFiled("(Required) Phone Number: ");
			phoneNumber = UITypeValidator.ValidateString(phoneNumber, "Not Valid Phone Number");
			string? address = UIDisplayhelper.DisplayInputFiled("(Optional) Address: ");
			address = UITypeValidator.ValidateSetNullIfEmty(address);
			string? email = UIDisplayhelper.DisplayInputFiled("(Optional) Email: ");
			email = UITypeValidator.ValidateSetNullIfEmty(email);
			Customer customer = _customerService.Update(new Customer(customerId, firstName, lastName, phoneNumber, email, address));
			return new DisplayMessage($"Updated with Id {customer.Id}", MassageType.Success);
		}
		catch (Exception ex)
		{
			return new DisplayMessage($"{ex.Message}", MassageType.Failed);
		}
	}
}
