using System;
using System.Collections.Generic;
using Core.Agents;
using UnityEngine;

namespace Industries.WorldMap.Agents.ActionZones
{
	[RequireComponent(typeof(Collider))]
	public class ActionZone : MonoBehaviour, IController
	{
		public event Action<IActionSender> ActionReceived;

		private readonly Dictionary<IActionSender, Action> mActionSenders = new Dictionary<IActionSender, Action>();

		private void OnTriggerEnter(Collider other)
		{
			var actionSender = GetSenderFromCollider(other);
			if (actionSender == null) return;
			actionSender.ActionTriggered += Callback;
			mActionSenders.Add(actionSender, Callback);

			void Callback() => ActionReceived?.Invoke(actionSender);
		}

		private void OnTriggerExit(Collider other)
		{
			var actionSender = GetSenderFromCollider(other);
			if (actionSender == null) return;
			if (mActionSenders.TryGetValue(actionSender, out var callback))
			{
				actionSender.ActionTriggered -= callback;
				mActionSenders.Remove(actionSender);
			}
		}

		private static IActionSender GetSenderFromCollider(Collider other)
		{
			return other.gameObject.GetComponentInChildren<ZoneIntruder>()?.ActionSender;
		}
	}
}