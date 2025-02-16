

using ContactManager.Contracts;
using System.Net;

namespace ContactManager.Contacts;
public class Customer
{
	public int Id { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }
	public string PhoneNumber { get; set; }
	public string? Email { get; set; }
	public string? Address { get; set; }
	public ICollection<Contract>? Contracts { get; set; }

	public Customer( string firstName, string lastName,string phoneNumber)
	{
		FirstName = firstName;
		LastName = lastName;
		PhoneNumber = phoneNumber;
	}

	public Customer(string firstName, string lastName, string phoneNumber, string? email, string? address) 
	{
		FirstName = firstName;
		LastName = lastName;
		PhoneNumber = phoneNumber;
		Email = email;
		Address = address;
	}
	public Customer(int id, string firstName, string lastName, string phoneNumber, string? email, string? address)
	{
		Id = id;
		FirstName = firstName;
		LastName = lastName;
		PhoneNumber = phoneNumber;
		Email = email;
		Address = address;
	}

	public void MakeEmptyStringsToNull()
	{
		Email = string.IsNullOrEmpty(Email) ? null : Email;
		Address = string.IsNullOrEmpty(Address) ? null : Address;
	}

	public override string ToString()
	{
		return $"Id: {Id}, " +
			   $"FirstName: {FirstName}, " +
			   $"LastName: {LastName}, " +
			   $"PhoneNumber: {PhoneNumber}, " +
			   $"Email: {Email ?? "NULL"}, " +
			   $"Address: {Address ?? "NULL"} ";
	}

	public override bool Equals(object? obj)
	{
		return obj is Customer customer &&
			   Id == customer.Id &&
			   FirstName == customer.FirstName &&
			   LastName == customer.LastName &&
			   PhoneNumber == customer.PhoneNumber &&
			   Email == customer.Email &&
			   Address == customer.Address &&
			   EqualityComparer<ICollection<Contract>?>.Default.Equals(Contracts, customer.Contracts);
	}

	public override int GetHashCode()
	{
		return HashCode.Combine(Id, FirstName, LastName, PhoneNumber, Email, Address, Contracts);
	}
}
