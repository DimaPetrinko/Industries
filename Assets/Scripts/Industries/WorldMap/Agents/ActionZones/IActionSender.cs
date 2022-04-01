using System;

namespace Industries.WorldMap.Agents.ActionZones
{
	public interface IActionSender
	{
		event Action ActionTriggered;
	}
}