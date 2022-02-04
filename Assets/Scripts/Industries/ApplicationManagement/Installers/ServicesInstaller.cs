using System.Linq;
using Core.ApplicationManagement.Installers;
using Core.DataManagement;
using Industries.Services;
using UnityEngine;

namespace Industries.ApplicationManagement.Installers
{
	public sealed class ServicesInstaller : IInstaller
	{
		public void Install()
		{
			var service1 = new Service1();
			var service2 = new Service2();
			var service3 = new Service3();
			var service4 = new Service4();

			Repository.Instance.Store(service1);
			Repository.Instance.Store(service2);
			Repository.Instance.Store(service3);
			Repository.Instance.Store(service4);

			var services = Repository.Instance.GetMany<IService>().ToArray();
			Debug.LogError(services.Length);
		}
	}
}