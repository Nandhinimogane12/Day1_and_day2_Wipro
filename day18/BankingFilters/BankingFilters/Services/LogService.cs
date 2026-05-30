namespace BankingFilters.Services
{
    public class LogService : ILogService
    {
        public void LogAction(string action, string user, string path)
            => Console.WriteLine($"[LOG] {DateTime.Now}: {user} - {action} - {path}");
        public void LogException(Exception ex, string path)
            => Console.WriteLine($"[ERROR] {DateTime.Now}: {ex.Message} - {path}");
    }
}