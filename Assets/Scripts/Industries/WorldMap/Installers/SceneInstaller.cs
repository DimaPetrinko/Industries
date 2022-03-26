using Core.ApplicationManagement.Installers;
using Core.DataManagement;
using Industries.WorldMap.Agents;
using UnityEngine;

namespace Industries.WorldMap.Installers
{
	public sealed class SceneInstaller : BaseSceneInstaller
	{
		[SerializeField] private ProductionPointController[] m_ProductionPointControllers;

		public override void Install()
		{
			Repository.Instance.Store(m_ProductionPointControllers);
		}

		public override void Uninstall()
		{
			Repository.Instance.Remove<ProductionPointController[]>();
		}
	}
}