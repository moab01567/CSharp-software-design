namespace ContactManager.UtilUI;

public static class UIDisplayhelper
{
	public static void DisplayList<T>(List<T> list)
	{
		Console.ForegroundColor = ConsoleColor.White;
		list.ForEach(item => Console.WriteLine(item));
		Console.Write("\n");
	}

	public static void DisplayText(DisplayMessage displayMassage)
	{
		if (string.IsNullOrEmpty(displayMassage.Massage)) return;

		Console.ForegroundColor = displayMassage.GetMassageColor();
		Console.WriteLine($"Response:\n{displayMassage.Massage}\n");
	}

	public static void DisplayClear()
	{
		Console.Clear();
	}

	public static string DisplayInputFiled()
	{
		Console.Write(">");
		string? input = Console.ReadLine();
		return input == null ? "" : input;
	}
	public static string DisplayInputFiled(string prompt)
	{
		Console.Write(prompt);
		string? input = Console.ReadLine();
		return input == null ? "" : input;
	}

	public static void DisplayHeader(string header, string menuName, ConsoleColor fontColor)
	{
		Console.ForegroundColor = fontColor;
		Console.WriteLine($"\n{header}\n");
		Console.WriteLine($"{menuName}\n");
	}
}
