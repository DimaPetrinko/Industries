using System.Linq;
using Core.Agents;
using Core.ApplicationManagement.Installers;
using Core.DataManagement;
using Industries.WorldMap.Models;
using UnityEngine;

namespace Industries.WorldMap.Agents
{
	public sealed class ProductionPointController : MonoBehaviour, IController, IInstallable
	{
		[SerializeField] private short m_Id;

		private ProductionPointData mPointData;

		bool IInstallable.Resolved { get; set; }

		public void Inject()
		{
			var worldMapData = Repository.Instance.Get<WorldMapData>();

			mPointData = worldMapData.ProductionPoints.FirstOrDefault(p => p.BasicData.Id == m_Id);
		}
	}
}