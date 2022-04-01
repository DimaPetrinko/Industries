using System.Linq;
using Core.Agents;
using Core.ApplicationManagement.Installers;
using Core.DataManagement;
using Industries.WorldMap.Agents.ActionZones;
using Industries.WorldMap.Models;
using UnityEngine;

namespace Industries.WorldMap.Agents
{
	public sealed class ProductionPointController : MonoBehaviour, IController, IInstallable
	{
		[SerializeField] private short m_Id;
		[SerializeField] private ActionZone m_JobActionZone;

		private ProductionPointData mPointData;

		bool IInstallable.Resolved { get; set; }

		public void Inject()
		{
			var worldMapData = Repository.Instance.Get<WorldMapData>();

			mPointData = worldMapData.ProductionPoints.FirstOrDefault(p => p.BasicData.Id == m_Id);
		}

		private void Awake()
		{
			m_JobActionZone.ActionReceived += OnActionReceived;
		}

		private void OnActionReceived(IActionSender sender)
		{
			if (sender is IJobReceiver jobReceiver)
			{
				jobReceiver.ReceiveJob(mPointData.Jobs[0]);
			}
		}
	}
}