using Core.ApplicationManagement.Runners;
using Industries.WorldMap.Installers;

namespace Industries.WorldMap.Runners
{
	public class SceneRunner : BaseSceneRunner
	{
		protected override void CreateInstallers()
		{
			mInstallers.Add(new RuntimeDataInstaller());
			mInstallers.Add(new ServicesInstaller());
		}
	}
}