using ContactManager.AbstactClasses;
using ContactManager.Contacts;
using ContactManager.Contacts.Contact;
using ContactManager.Contracts;
using ContactManager.Customers;
using ContactManager.Database;
using ContactManager.Houses;
using ContactManager.Interfaces;

namespace ContactManager
{
	internal class Program {
		static void Main(string[] args) {
			new Application().Setup();
		}
	}
}