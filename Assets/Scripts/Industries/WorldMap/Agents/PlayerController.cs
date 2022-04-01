using System;
using Industries.WorldMap.Agents.ActionZones;
using Industries.WorldMap.Models;
using UnityEngine;

namespace Industries.WorldMap.Agents
{
	// TODO: very bare mock to test the functionality
	public interface IPlayerController : IActionSender, IJobReceiver {}

	public sealed class PlayerController : MonoBehaviour, IPlayerController
	{
		public event Action ActionTriggered;

		[SerializeField] private ZoneIntruder m_ZoneIntruder;

		private void Awake() { m_ZoneIntruder.ActionSender = this; }

		public void ReceiveJob(JobData job)
		{
			Debug.LogError($"job from {job.Origin.Name} to {job.Destination.Name}");
		}

		private void Update()
		{
			if (Input.GetKeyDown(KeyCode.F)) ActionTriggered?.Invoke();
		}
	}
}