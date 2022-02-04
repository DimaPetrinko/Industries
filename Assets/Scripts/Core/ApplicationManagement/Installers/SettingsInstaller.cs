using UnityEngine;

namespace Core.ApplicationManagement.Installers
{
	public abstract class SettingsInstaller : ScriptableObject, IInstaller
	{
		public abstract void Install();
	}
}