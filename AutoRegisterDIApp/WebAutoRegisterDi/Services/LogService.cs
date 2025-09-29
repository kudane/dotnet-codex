using NetCore.AutoRegisterDi;

namespace WebAutoRegisterDi.Services
{
    [RegisterAsScoped]
    public class LogService : ILogService
    {
        public void LogInfo(string message)
        {
            Console.WriteLine($"Info: {message}");
        }
    }
}
