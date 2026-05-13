namespace ECommerceFilters.Services
{
    public interface ILogService
    {
        void LogRequest(string controller, string action, string method, string url, int statusCode);
        void LogException(Exception ex, string path);
    }
}