namespace ContactManager.UtilUI;

public class UITypeValidator
{

	public static int ValidateInt(string id, string errorMassage)
	{
		int Id2 = 0;
		if (!int.TryParse(id, out Id2)) throw new ArgumentException(errorMassage);
		return Id2;
	}
	public static string ValidateString(string text, string errorMassage)
	{
		if (string.IsNullOrEmpty(text)) throw new ArgumentException(errorMassage);
		return text;
	}
	public static string? ValidateSetNullIfEmty(string? text)
	{
		if (string.IsNullOrEmpty(text)) text = null;
		return text;
	}
	public static bool ValidateYesOrNo(string text)
	{
		if (text == "y") return true;
		return false;
	}

}
