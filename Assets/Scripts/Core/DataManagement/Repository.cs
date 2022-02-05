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
			return GetMany<T>().FirstOrDefault();
		}

		public IEnumerable<T> GetMany<T>() where T : class
		{
			return GetManyPairs<T>()
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

		public void Remove<T>() where T : class
		{
			var keyToRemove = GetManyPairs<T>()
				.Select(p => p.Key)
				.FirstOrDefault();
			if (keyToRemove == null)
			{
				Debug.LogWarning($"Nothing to remove. Type {typeof(T)}");
				return;
			}

			mStorage.Remove(keyToRemove);
		}

		public void RemoveAll<T>() where T : class
		{
			var keysToRemove = GetManyPairs<T>()
				.Select(p => p.Key)
				.ToArray();
			if (keysToRemove.Length == 0)
			{
				Debug.LogWarning($"Nothing to remove. Type {typeof(T)}");
				return;
			}

			foreach (var key in keysToRemove)
			{
				mStorage.Remove(key);
			}
		}

		private IEnumerable<KeyValuePair<Type, object>> GetManyPairs<T>() where T : class
		{
			return mStorage
				.Select(p => new
				{
					Comparison = SearchComparison(p.Key, typeof(T)),
					Pair = p
				})
				.Where(r => r.Comparison > 0)
				.OrderByDescending(r => r.Comparison)
				.Select(p => p.Pair);
		}

		private static int SearchComparison(Type current, Type target)
		{
			if (current == target) return 2;
			if (current.GetInterfaces().Contains(target)) return 1;
			return 0;
		}
	}
}