using System;
using Core.Models;
using UnityEngine;

namespace Industries.WorldMap.Models
{
	[Serializable]
	public class ProductionPointData : IData
	{
		[SerializeField] private ProductionPointBasicData m_BasicData;
		[SerializeField] private JobData[] m_Jobs;

		public ProductionPointBasicData BasicData => m_BasicData;
		public JobData[] Jobs => m_Jobs;
	}
}