namespace MonitoringApp.Domain.Entities
{
	public class PlatformStatus
	{
		public int Id { get; set; }           
		public string PlatformName { get; set; } = string.Empty;
		public string Version { get; set; } = string.Empty;
		public string Status { get; set; } = string.Empty;
		public DateTime CheckedAt { get; set; } = DateTime.UtcNow; 
	}
}
