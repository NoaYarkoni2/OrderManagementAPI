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
            var session = await (from Wapp in _context.Wapp
                                 join Script in _context.Script on Wapp.ACCNT_CODE equals Script.ACCNT_CODE
                                 join Sessions in _context.Sessions on Script.CODE equals Sessions.SESS_TMPL_ID
                                 where Wapp.ACCNT_CODE == accntCode && Sessions.SESS_TMPL_ID == sessTmplId
                                 select Sessions).FirstOrDefaultAsync();

            return session;
        }


        public async Task<List<Session>> GetAllSessionsAsync()
        {
            return await _context.Sessions.ToListAsync();
        }

        //public async Task<Session> GetSessionByIdAsync(int id)
        //{
        //    return await _context.Sessions.FindAsync(id);
        //}


    }
}
