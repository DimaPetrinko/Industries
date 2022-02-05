using Core.Presenters;
using UnityEngine;

namespace Industries.WorldMap.Presenters
{
	public class ProductionPointSpawnPresenter : MonoBehaviour, IPresenter
	{
		[SerializeField] private Transform m_SpawnParent;

		public Transform SpawnParent => m_SpawnParent;
	}
}