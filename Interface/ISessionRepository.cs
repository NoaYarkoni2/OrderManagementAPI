using OrderManagementAPI.Models;

namespace OrderManagementAPI.Interface
{
    public interface ISessionRepository
    {
        Task<Session> LoginAsync(string accntCode, string sessTmplId);
        Task<List<Session>> GetAllSessionsAsync();
        Task<List<Session>> GetSessionsByCustomerNameAsync(string customerName);
        Task<List<Scripts>> GetCustomerScriptsAsync(string accountCode);
        Task<List<Session>> GetSessionsByScriptCodeAsync(string code);
        Task ResetSessionAsync(string sessionId);
        Task ResetMessageStatusAsync(string sessionId);


    }
}
