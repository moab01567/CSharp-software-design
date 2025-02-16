using ContactManager.AbstactClasses;
using ContactManager.Database;
using ContactManager.Interfaces;

namespace ContactManager.Contracts;

public class ContractRepository : AbstractRepository<Contract>
{
	public ContractRepository(HomeSalesDbContext db) : base(db){}
}
