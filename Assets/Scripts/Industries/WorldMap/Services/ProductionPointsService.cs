using Core.ApplicationManagement.Installers;
using Core.DataManagement;
using Core.Services;
using Industries.WorldMap.Agents;
using UnityEngine;

namespace Industries.WorldMap.Services
{
	public class ProductionPointsService : IService
	{
		private ProductionPointController[] mProductionPointControllers;

		bool IInstallable.Resolved { get; set; }
		bool IService.Running { get; set; }

		public void Inject()
		{
			mProductionPointControllers = Repository.Instance.Get<ProductionPointController[]>();
		}

		public void Start()
		{
			Debug.Log($"Points {mProductionPointControllers.Length}");
		}

		public void Stop()
		{
		}
	}
}