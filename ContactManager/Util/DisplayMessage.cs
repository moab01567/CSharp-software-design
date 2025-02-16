namespace ContactManager.UtilUI;

public class DisplayMessage
{
	private string _massage;
	private MassageType _massageType;
	public string Massage
	{
		get => _massage;
	}

	public DisplayMessage(string massage, MassageType massageType)
	{
		_massage = massage;
		_massageType = massageType;
	}

	public ConsoleColor GetMassageColor()
	{
		switch (_massageType)
		{
			case MassageType.Info:
				return ConsoleColor.Blue;
			case MassageType.Success:
				return ConsoleColor.Green;
			case MassageType.Failed:
				return ConsoleColor.Red;
			default:
				return ConsoleColor.White;
		}
	}

}
