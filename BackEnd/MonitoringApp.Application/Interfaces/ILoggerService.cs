namespace MonitoringApp.Application.Interfaces
{
	public interface ILoggerService<T>
	{
		void LogInformation(string message);
		void LogWarning(string message);
		void LogError(string message, Exception ex);
	}
}
