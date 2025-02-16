using ContactManager.Contacts;
using System.Data.SqlTypes;


namespace ContactManager.Interfaces;

public interface IBaseService<T>
{
	public T CheckIfExist(int id, String massage);
	public T Add(T entity);
	public T Update(T entity);
	public void Delete(int id);
	public T GetById(int id);
	public List<T> GetAll();
}
