namespace JobsApp.Models
{
    public class AppConfig
    {
        public Logging Logging { get; set; }
        public ConnectionStrings ConnectionStrings { get; set; }
        public string AllowedHosts { get; set; }
    }
    public class Logging
    {
        public LogLevel LogLevel { get; set; }
    }
    public class LogLevel
    {
        public string Default { get; set; }
        [ConfigurationKeyName("Microsoft.AspNetCore")]
        public string MicrosoftAspNetCore { get; set; }
    }
    public class ConnectionStrings
    {
        public string DefaultConnection { get; set; }
    }
}
