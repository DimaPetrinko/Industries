using Core.Models;
using Industries.Utils;
using UnityEngine;

namespace Industries.WorldMap.Models
{
	[CreateAssetMenu(
		menuName = ApplicationConstants.ProjectName + "/Settings/" + nameof(WorldMapData),
		fileName = nameof(WorldMapData), order = 0)]
	public class WorldMapData : ScriptableObject, IData
	{
		[SerializeField] private ProductionPointData[] m_ProductionPoints;

		public ProductionPointData[] ProductionPoints => m_ProductionPoints;
	}
}