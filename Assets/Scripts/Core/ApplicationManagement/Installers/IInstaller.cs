namespace Core.ApplicationManagement.Installers
{
	/// <summary>
	/// Is a class that adds other classes to the repository and removes them when the time comes
	/// </summary>
	public interface IInstaller
	{
		void Install();
		void Uninstall();
	}
}