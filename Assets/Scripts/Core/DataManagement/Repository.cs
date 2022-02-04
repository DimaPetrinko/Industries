using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Core.DataManagement
{
	public sealed class Repository : IRepository
	{
		#region Singleton

		public static IRepository Instance => mInstance ??= new Repository();

		private static IRepository mInstance;

		#endregion

		private readonly Dictionary<Type, object> mStorage;

		public Repository()
		{
			mStorage = new Dictionary<Type, object>();
		}

		public T Get<T>() where T : class
		{
			var targetType = typeof(T);
			return (T)mStorage
				.FirstOrDefault(p => SearchCondition(p.Key, targetType))
				.Value;
		}

		public IEnumerable<T> GetMany<T>() where T : class
		{
			var targetType = typeof(T);
			return mStorage
				.Where(p => SearchCondition(p.Key, targetType))
				.Select(p => p.Value)
				.Cast<T>();
		}

		public void Store<T>(T data) where T : class
		{
			var type = typeof(T);
			if (mStorage.ContainsKey(type))
			{
				Debug.LogWarning($"The repository storage already contains the data of type {type}. replacing it with {data}");
			}
			mStorage[type] = data;
		}

		private static bool SearchCondition(Type current, Type target)
		{
			return current == target || current.GetInterfaces().Contains(target);
		}
	}
}