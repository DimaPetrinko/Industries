using Core.ApplicationManagement.Runners;
using Industries.ApplicationManagement.Installers;

namespace Industries.ApplicationManagement.Runners
{
	public class StartupSceneRunner : SceneRunner
	{
		protected override void CreateInstallers()
		{
			mInstallers.Add(new RuntimeDataInstaller());
			mInstallers.Add(new ServicesInstaller());
		}
	}
}