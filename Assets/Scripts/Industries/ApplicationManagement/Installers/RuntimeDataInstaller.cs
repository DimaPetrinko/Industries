using Core.ApplicationManagement.Installers;
using Core.DataManagement;
using Industries.Models;
using UnityEngine;

namespace Industries.ApplicationManagement.Installers
{
	public sealed class RuntimeDataInstaller : IInstaller
	{
		public void Install()
		{
			Repository.Instance.Store(new TestData());

			var testData = Repository.Instance.Get<ITestData>();
			Debug.Log(testData.TestString);
		}

		public void Uninstall()
		{
			Repository.Instance.Remove<ITestData>();
		}
	}
}