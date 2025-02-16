
namespace ContactManager.Houses;

public class House
{
	public int Id { get; set; }
	public string Address { get; set; } = "NO Address provided yet";
	public int Price { get; set; }
	public string? Description { get; set; }
	public bool IsBuild { get; set; }


	public static int operator + (House a, House b)
	{
		return a.Price + b.Price;
	}
	public static bool operator - (House a, House b)
	{
		return (a.Id - b.Id) == 0;
	}
	public static int operator *(House house, int number)
	{
		return house.Price * number;
	}
	public override string ToString()
	{
		return $"Id: {Id}, " +
			   $"Address: {Address}, " +
			   $"Price: {Price}, " +
			   $"Description: {(string.IsNullOrEmpty(Description) ? "No Description" : Description)}, " +
			   $"IsBuild: {IsBuild}";
	}

}
