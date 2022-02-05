using Core.ApplicationManagement.Installers;
using Core.DataManagement;
using Industries.WorldMap.Services;

namespace Industries.WorldMap.Installers
{
	public sealed class ServicesInstaller : IInstaller
	{
		public void Install()
		{
			Repository.Instance.Store(new ProductionPointsSpawnService());
		}

		public void Uninstall()
		{
			Repository.Instance.Remove<ProductionPointsSpawnService>();
		}
	}
}