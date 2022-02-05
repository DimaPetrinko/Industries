using Core.ApplicationManagement.Installers;
using Core.DataManagement;
using Industries.Utils;
using Industries.WorldMap.Models;
using UnityEngine;

namespace Industries.WorldMap.Installers
{
	[CreateAssetMenu(
		menuName = ApplicationConstants.ProjectName + "/Installers/" + nameof(SettingsInstaller),
		fileName = nameof(SettingsInstaller), order = 0
	)]
	public sealed class SettingsInstaller : BaseSettingsInstaller
	{
		[SerializeField] private WorldMapData m_WorldMapData;

		public override void Install()
		{
			Repository.Instance.Store(m_WorldMapData);
		}

		public override void Uninstall()
		{
			Repository.Instance.Remove<WorldMapData>();
		}
	}
}