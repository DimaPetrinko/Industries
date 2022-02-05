using UnityEngine;

namespace Core.ApplicationManagement.Installers
{
	public abstract class BaseSettingsInstaller : ScriptableObject, IInstaller
	{
		public abstract void Install();
		public abstract void Uninstall();
	}
}