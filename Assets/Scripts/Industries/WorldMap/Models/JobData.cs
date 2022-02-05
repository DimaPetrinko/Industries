using System;
using Core.Models;
using UnityEngine;

namespace Industries.WorldMap.Models
{
	[Serializable]
	public class JobData : IData
	{
		[SerializeField] private ProductionPointBasicData m_Origin;
		[SerializeField] private ProductionPointBasicData m_Destination;
		[SerializeField] private float m_Duration;
		[SerializeField] private float m_Reward;

		public ProductionPointBasicData Origin => m_Origin;
		public ProductionPointBasicData Destination => m_Destination;
		public float Duration => m_Duration;
		public float Reward => m_Reward;
	}
}