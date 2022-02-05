using System.Collections.Generic;
using System.Linq;
using Core.ApplicationManagement.Installers;
using Core.DataManagement;
using Core.Services;
using UnityEngine;

namespace Core.ApplicationManagement.Runners
{
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
		}

		private void Start()
		{
			mServices = Repository.Instance.GetMany<IService>().ToList();
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