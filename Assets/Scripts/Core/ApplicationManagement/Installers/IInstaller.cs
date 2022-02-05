namespace Core.ApplicationManagement.Installers
{
	public interface IInstaller
	{
		void Install();
		void Uninstall();
	}
}