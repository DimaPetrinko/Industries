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
		[SerializeField] private Vector3 m_Position;
		[SerializeField] private GameObject m_Prefab;

		public short Id => m_Id;
		public string Name => m_PointName;
		public string Description => m_Description;
		public Vector3 Position => m_Position;
		public GameObject Prefab => m_Prefab;
	}
}