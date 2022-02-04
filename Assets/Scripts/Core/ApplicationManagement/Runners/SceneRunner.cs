using Core.ApplicationManagement.Installers;
using UnityEngine;

namespace Core.ApplicationManagement.Runners
{
	public abstract class SceneRunner : MonoBehaviour
	{
		[SerializeField] private SettingsInstaller m_SettingsInstaller;
		[SerializeField] private SceneInstaller m_SceneInstaller;

		private void Awake()
		{
			m_SettingsInstaller.Install();
			m_SceneInstaller.Install();
			Initialize();
		}

		private void Start()
		{
			Run();
		}

		protected abstract void Initialize();
		protected abstract void Run();
	}
}