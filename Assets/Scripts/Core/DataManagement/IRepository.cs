using System.Collections.Generic;

namespace Core.DataManagement
{
	public interface IRepository
	{
		T Get<T>() where T : class;
		IEnumerable<T> GetMany<T>() where T : class;
		void Store<T>(T data) where T : class;
		void Remove<T>() where T : class;
		void RemoveAll<T>() where T : class;
	}
}