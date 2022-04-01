using Industries.WorldMap.Models;

namespace Industries.WorldMap.Agents
{
	public interface IJobReceiver
	{
		void ReceiveJob(JobData job);
	}
}