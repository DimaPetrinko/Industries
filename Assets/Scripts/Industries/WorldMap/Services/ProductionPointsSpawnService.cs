using System.Collections.Generic;
using System.Linq;
using Core.DataManagement;
using Core.Services;
using Industries.WorldMap.Models;
using Industries.WorldMap.Presenters;
using UnityEngine;

namespace Industries.WorldMap.Services
{
	public class ProductionPointsSpawnService : IService
	{
		private readonly WorldMapData mWorldMapData;
		private readonly ProductionPointSpawnPresenter mProductionPointSpawnPresenter;

		private  List<GameObject> mSpawnedPoints;

		public ProductionPointsSpawnService()
		{
			mWorldMapData = Repository.Instance.Get<WorldMapData>();
			mProductionPointSpawnPresenter = Repository.Instance.Get<ProductionPointSpawnPresenter>();
		}

		public void Start()
		{
			Debug.Log($"Pew! Spawning {mWorldMapData.ProductionPoints.Length} production points");
			mSpawnedPoints = mWorldMapData
				.ProductionPoints
				.Select(p =>
				{
					var instance = Object.Instantiate(
						p.BasicData.Prefab,
						mProductionPointSpawnPresenter.SpawnParent
					);
					instance.transform.localPosition = p.BasicData.Position;
					return instance;
				})
				.ToList();
		}

		public void Stop()
		{
			Debug.Log($"Pew! Destroying {mWorldMapData.ProductionPoints.Length} production points");
			foreach (var point in mSpawnedPoints)
			{
				Object.Destroy(point);
			}
			mSpawnedPoints.Clear();
		}
	}
}