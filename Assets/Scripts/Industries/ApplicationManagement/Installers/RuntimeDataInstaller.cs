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
			ITestData testData = new TestData();

			Repository.Instance.Store(testData);

			var testData2 = Repository.Instance.Get<ITestData>();
			Debug.Log(testData2.TestString);
		}
	}
}