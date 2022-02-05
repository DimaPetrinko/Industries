using Core.ApplicationManagement.Installers;
using Industries.Utils;
using UnityEngine;

namespace Industries.ApplicationManagement.Installers
{
	[CreateAssetMenu(
		menuName = ApplicationConstants.ProjectName + "/Installers/" + nameof(StartupSettingsInstaller),
		fileName = nameof(StartupSettingsInstaller), order = 0
	)]
	public sealed class StartupSettingsInstaller : SettingsInstaller
	{
		public override void Install()
		{
		}

		public override void Uninstall()
		{
		}
	}
}