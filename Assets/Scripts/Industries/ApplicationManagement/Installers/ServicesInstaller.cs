using System.Linq;
using Core.ApplicationManagement.Installers;
using Core.DataManagement;
using Core.Services;
using Industries.Services;
using UnityEngine;

namespace Industries.ApplicationManagement.Installers
{
	public sealed class ServicesInstaller : IInstaller
	{
		public void Install()
		{
			Repository.Instance.Store(new Service1());
			Repository.Instance.Store(new Service2());
			Repository.Instance.Store(new Service3());
			Repository.Instance.Store(new Service4());

			var services = Repository.Instance.GetMany<IService>().ToArray();
			Debug.LogError(services.Length);
		}

		public void Uninstall()
		{
			Repository.Instance.RemoveAll<IService>();
		}
	}
}