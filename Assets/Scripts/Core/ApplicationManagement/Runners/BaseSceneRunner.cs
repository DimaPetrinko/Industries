using System.Collections.Generic;
using System.Linq;
using Core.ApplicationManagement.Installers;
using Core.DataManagement;
using Core.Services;
using UnityEngine;

namespace Core.ApplicationManagement.Runners
{
	// 0. Repository is a place where everything lives. The contents can be accessed, altered and so on
	// 1. Scene runner is an entry point
	//    It gathers/creates installers:
	//    - Every runner has a settings installer (scriptable object)
	//    - Every runner has a scene installer (mono behavior)
	//    Installs them
	//    Resolves everything in the repository
	//    Then runs all newly added services
	// 2. Installers add what is needed to the Repository
	// 3. Services are manager that do some work
	// 4. Controllers control the view on the scene (UI or otherwise)
	// 5. Presenters are reference holders. They allow accessing objects on the scene in non mono behavior classes

	public abstract class BaseSceneRunner : MonoBehaviour
	{
		[SerializeField] private BaseSettingsInstaller m_SettingsInstaller;
		[SerializeField] private BaseSceneInstaller m_SceneInstaller;

		protected List<IInstaller> mInstallers;
		private List<IService> mServices;

		private void Awake()
		{
			mInstallers = new List<IInstaller>();

			if (m_SettingsInstaller != null) mInstallers.Add(m_SettingsInstaller);
			if (m_SceneInstaller != null) mInstallers.Add(m_SceneInstaller);
			CreateInstallers();
			Install();
			Resolve();
		}

		private void Start()
		{
			mServices = Repository.Instance.GetAllNonRunningServices().ToList();
			Run();
		}

		private void OnDestroy()
		{
			Stop();
			Uninstall();
		}

		protected abstract void CreateInstallers();

		private void Install()
		{
			foreach (var installer in mInstallers)
			{
				installer.Install();
			}
		}

		private void Uninstall()
		{
			foreach (var installer in mInstallers)
			{
				installer.Uninstall();
			}
		}

		private void Resolve()
		{
			Repository.Instance.ResolveAll();
		}

		private void Run()
		{
			foreach (var service in mServices)
			{
				service.Start();
				service.Running = true;
			}
		}

		private void Stop()
		{
			foreach (var service in mServices)
			{
				service.Stop();
				service.Running = false;
			}
		}
	}
}