using OrderManagementAPI.Models;

namespace OrderManagementAPI.Interface
{
    public interface ISessionRepository
    {
        Task<Session> LoginAsync(string accntCode, string sessTmplId);
        Task<List<Session>> GetAllSessionsAsync();
        //Task<IEnumerable<Session>> GetAllSessionsAsync();
        //Task<Session> GetSessionByIdAsync(int id);
    }
}
