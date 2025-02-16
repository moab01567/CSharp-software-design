using ContactManager.Database;

namespace ContactManager.AbstactClasses;

public abstract class AbstractRepository<T> where T : class
{
	protected readonly HomeSalesDbContext _db;

	public AbstractRepository(HomeSalesDbContext db)
	{
		_db = db;
	}
	public  T Add(T entity)
	{
		_db.Set<T>().Add(entity);
		_db.SaveChanges();
		return entity;
	}
	public List<T> AddRange(List<T> entities)
	{
		_db.Set<T>().AddRange(entities);
		_db.SaveChanges();
		return entities;
	}
	public void Delete(int id)
	{
		T? entity = _db.Set<T>().Find(id);
		if (entity != null)
		{
			_db.Set<T>().Remove(entity);
			_db.SaveChanges();
		}
	}
	public  List<T> GetAll()
	{
		return _db.Set<T>().Select(c => c).ToList();
	}
	public  T? GetById(int id)
	{	
		T? entity = _db.Set<T>().Find(id);
		return entity;
	}
	public T Update(T entity)
	{
		_db.Set<T>().Update(entity);
		_db.SaveChanges();
		return entity;
	}
}
