using ContactManager.UtilUI;

namespace ContactManager.AbstactClasses;

public abstract class AbstractUI
{
	protected virtual string _header { get; } = "  _   _       _     ____                 _     _          _ \r\n | \\ | | ___ | |_  |  _ \\ _ __ _____   _(_) __| | ___  __| |\r\n |  \\| |/ _ \\| __| | |_) | '__/ _ \\ \\ / / |/ _` |/ _ \\/ _` |\r\n | |\\  | (_) | |_  |  __/| | | (_) \\ V /| | (_| |  __/ (_| |\r\n |_| \\_|\\___/ \\__| |_|   |_|  \\___/ \\_/ |_|\\__,_|\\___|\\__,_|\r\n                                                            ";
	protected virtual string _menuName { get; } = "No Menu Provided";
	protected virtual List<string> _menuOptions { get; } = new List<string> { "No Menu Options" };

	protected void DisplayUI(DisplayMessage displayMessage)
	{
		UIDisplayhelper.DisplayClear();
		UIDisplayhelper.DisplayHeader(_header, _menuName, ConsoleColor.White);
		UIDisplayhelper.DisplayText(displayMessage);
		UIDisplayhelper.DisplayList(_menuOptions);
	}

	public virtual void Run()
	{
		DisplayUI(new DisplayMessage("The run method not overrided :)", MassageType.Info));
	}
}
