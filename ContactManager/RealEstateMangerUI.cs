using ContactManager.AbstactClasses;
using ContactManager.Contracts;
using ContactManager.Customers;
using ContactManager.Houses;
using ContactManager.UtilUI;

namespace ContactManager;
class RealEstateMangerUI : AbstractUI
{
	protected override string _header { get; } = "  ____            _       _____     _        _         __  __                             \r\n |  _ \\ ___  __ _| |     | ____|___| |_ __ _| |_ ___  |  \\/  | __ _ _ __   __ _  ___ _ __ \r\n | |_) / _ \\/ _` | |_____|  _| / __| __/ _` | __/ _ \\ | |\\/| |/ _` | '_ \\ / _` |/ _ \\ '__|\r\n |  _ <  __/ (_| | |_____| |___\\__ \\ || (_| | ||  __/ | |  | | (_| | | | | (_| |  __/ |   \r\n |_| \\_\\___|\\__,_|_|     |_____|___/\\__\\__,_|\\__\\___| |_|  |_|\\__,_|_| |_|\\__, |\\___|_|   \r\n                                                                          |___/           ";
	protected override string _menuName { get; } = "Main menu";
	protected override List<string> _menuOptions { get; } = new List<string>
	{
	"Press 1 to Manage customers",
	"Press 2 to Manage houses",
	"Press 3 to Manage contracts",
	"Press 'q' to Exit the program."
	};
	private AbstractUI _customerUI;
	private AbstractUI _houseUI;
	private AbstractUI _contractUI;

	public RealEstateMangerUI(AbstractUI customerUI, AbstractUI houseUI, AbstractUI contractUI)
	{
		_customerUI = customerUI;
		_houseUI = houseUI;
		_contractUI = contractUI;
	}


	public override void Run()
	{
		bool quit = false;
		DisplayMessage displayMassage = new("", MassageType.Info);
		while (!quit)
		{
			DisplayUI(displayMassage);

			switch (UIDisplayhelper.DisplayInputFiled())
			{
				case "1":
					_customerUI.Run();
					break;
				case "2":
					_houseUI.Run();
					break;
				case "3":
					_contractUI.Run();
					break;
				case "q":
					quit = true;
					break;
				default:
					break;
			}
		}
	}
}