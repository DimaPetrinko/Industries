using UnityEngine;

namespace Core.ApplicationManagement.Installers
{
	public abstract class BaseSceneInstaller : MonoBehaviour, IInstaller
	{
		public abstract void Install();
		public abstract void Uninstall();
	}
}