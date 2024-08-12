using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.Data;
using OrderManagementAPI.Interface;
using OrderManagementAPI.Models;

namespace OrderManagementAPI.Repositories
{
    public class SessionRepository : ISessionRepository
    {
        private readonly ApplicationDbContext _context;

        public SessionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Session> LoginAsync(string accntCode, string sessTmplId)
        {
            // Perform the necessary join
            var session = await (from wapp in _context.wapp
                                 join scripts in _context.scripts on wapp.ACCNT_CODE equals scripts.ACCNT_CODE
                                 join Sessions in _context.sessions on scripts.CODE equals Sessions.SESS_TMPL_ID
                                 where wapp.ACCNT_CODE == accntCode && Sessions.SESS_TMPL_ID == sessTmplId
                                 select Sessions).FirstOrDefaultAsync();

            return session;
        }


        public async Task<List<Session>> GetAllSessionsAsync()
        {
            return await _context.sessions.ToListAsync();
        }

        //public async Task<Session> GetSessionByIdAsync(int id)
        //{
        //    return await _context.Sessions.FindAsync(id);
        //}


    }
}
