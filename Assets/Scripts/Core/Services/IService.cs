using Core.ApplicationManagement.Installers;

namespace Core.Services
{
	/// <summary>
	/// Is a class that manages working agents to make some system work. Also is installable
	/// </summary>
	public interface IService : IInstallable
	{
		bool Running { get; set; }
		void Start();
		void Stop();
	}
}