namespace Core.ApplicationManagement.Installers
{
	/// <summary>
	/// Is a class that uses things from the repository after everything was added
	/// </summary>
	public interface IInstallable
	{
		bool Resolved { get; set; }
		void Inject();
	}
}