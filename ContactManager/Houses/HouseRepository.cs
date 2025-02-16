
using ContactManager.AbstactClasses;
using ContactManager.Database;
using ContactManager.Interfaces;

namespace ContactManager.Houses;

public class HouseRepository : AbstractRepository<House>
{
	public HouseRepository(HomeSalesDbContext db) : base(db){}
}
