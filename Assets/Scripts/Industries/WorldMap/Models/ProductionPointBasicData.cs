using Core.Models;
using Industries.Utils;
using UnityEngine;

namespace Industries.WorldMap.Models
{
	[CreateAssetMenu(
		menuName = ApplicationConstants.ProjectName + "/Settings/" + nameof(ProductionPointBasicData),
		fileName = nameof(ProductionPointBasicData), order = 0)]
	public class ProductionPointBasicData : ScriptableObject, IData
	{
		[SerializeField] private short m_Id;
		[SerializeField] private string m_PointName;
		[SerializeField] private string m_Description;

		public short Id => m_Id;
		public string Name => m_PointName;
		public string Description => m_Description;
	}
}