using Core.ApplicationManagement.Installers;
using Core.DataManagement;
using Industries.WorldMap.Presenters;
using UnityEngine;

namespace Industries.WorldMap.Installers
{
	public sealed class SceneInstaller : BaseSceneInstaller
	{
		[SerializeField] private ProductionPointSpawnPresenter m_ProductionPointSpawnPresenter;

		public override void Install()
		{
			Repository.Instance.Store(m_ProductionPointSpawnPresenter);
		}

		public override void Uninstall()
		{
			Repository.Instance.Remove<ProductionPointSpawnPresenter>();
		}
	}
}