using System.Collections.Generic;
using System.Linq;
using Core.ApplicationManagement.Installers;
using Core.DataManagement;
using Core.Services;
using UnityEngine;

namespace Core.ApplicationManagement.Runners
{
	public abstract class SceneRunner : MonoBehaviour
	{
		[SerializeField] private SettingsInstaller m_SettingsInstaller;
		[SerializeField] private SceneInstaller m_SceneInstaller;

		protected List<IInstaller> mInstallers;
		private List<IService> mServices;

		private void Awake()
		{
			mInstallers = new List<IInstaller>();

			CreateInstallers();

			m_SettingsInstaller.Install();
			m_SceneInstaller.Install();
			InstallOther();
		}

		private void Start()
		{
			mServices = Repository.Instance.GetMany<IService>().ToList();
			Run();
		}

		private void OnDestroy()
		{
			Stop();
			UninstallOther();
		}

		protected abstract void CreateInstallers();

		private void InstallOther()
		{
			foreach (var installer in mInstallers)
			{
				installer.Install();
			}
		}

		private void UninstallOther()
		{
			foreach (var installer in mInstallers)
			{
				installer.Uninstall();
			}
		}

		private void Run()
		{
			foreach (var service in mServices)
			{
				service.Start();
			}
		}

		private void Stop()
		{
			foreach (var service in mServices)
			{
				service.Stop();
			}
		}
	}
}