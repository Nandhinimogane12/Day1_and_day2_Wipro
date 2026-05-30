namespace ECommerceFilters.Services
{
    public class LogService : ILogService
    {
        private readonly IWebHostEnvironment _env;
        private readonly string _logPath;

        public LogService(IWebHostEnvironment env)
        {
            _env = env;
            _logPath = Path.Combine(_env.ContentRootPath, "logs.txt");
        }

        public void LogRequest(string controller, string action, string method, string url, int statusCode)
        {
            var log = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | {method} {url} | {controller}/{action} | Status: {statusCode}\n";
            File.AppendAllText(_logPath, log);
        }

        public void LogException(Exception ex, string path)
        {
            var log = $"{DateTime.Now:yyyy-MM-dd HH:mm:ss} | ERROR | Path: {path} | {ex.Message}\n{ex.StackTrace}\n\n";
            File.AppendAllText(_logPath, log);
        }
    }
}