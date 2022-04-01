using Core.Agents;
using UnityEngine;

namespace Industries.WorldMap.Agents.ActionZones
{
	public class ZoneIntruder : MonoBehaviour, IPresenter
	{
		public IActionSender ActionSender { get; set; }
	}
}