using Core.ApplicationManagement.Runners;
using Industries.ApplicationManagement.Installers;

namespace Industries.ApplicationManagement.Runners
{
	public class StartupSceneRunner : SceneRunner
	{
		protected override void Initialize()
		{
			var runtimeDataInstaller = new RuntimeDataInstaller();
			var servicesInstaller = new ServicesInstaller();

			runtimeDataInstaller.Install();
			servicesInstaller.Install();
		}

		protected override void Run()
		{
		}
	}
}