
using ContactManager.Contacts;
using ContactManager.Houses;

namespace ContactManager.Contracts;

public class Contract
{
	public int Id { get; set; }
	public int Paid { get; set; }
	public int CustomerId { get; set; }
	public Customer? Customer { get; set; }
	public int HouseId { get; set; }
	public House? House { get; set; }

	public override bool Equals(object? obj)
	{
		return obj is Contract contract &&
			   Id == contract.Id &&
			   Paid == contract.Paid &&
			   CustomerId == contract.CustomerId &&
			   EqualityComparer<Customer?>.Default.Equals(Customer, contract.Customer) &&
			   HouseId == contract.HouseId &&
			   EqualityComparer<House?>.Default.Equals(House, contract.House);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Id, Paid, CustomerId, Customer, HouseId, House);
	}

	public override string ToString()
	{
		return $"Id: {Id}, " +
			   $"Paid: {Paid}, " +
			   $"CustomerId: {CustomerId}, " +
			   $"HouseId: {HouseId}, ";
	}
}
