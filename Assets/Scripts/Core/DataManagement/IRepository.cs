using System.Collections.Generic;
using Core.Services;

namespace Core.DataManagement
{
	/// <summary>
	/// The main storage for everything
	/// </summary>
	public interface IRepository
	{
		T Get<T>() where T : class;
		IEnumerable<T> GetMany<T>() where T : class;
		void Store<T>(T data) where T : class;
		void Remove<T>() where T : class;
		void RemoveAll<T>() where T : class;
		void ResolveAll();
		IEnumerable<IService> GetAllNonRunningServices();
	}
}