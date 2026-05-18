namespace BookStoreApp.Services
{
    public interface ILogService
    {
        void LogAction(string action, string user, string path);
        void LogException(Exception ex, string path);
    }
}