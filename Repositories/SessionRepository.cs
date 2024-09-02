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

        public async Task<List<Session>> GetSessionsByCustomerNameAsync(string customerName)
        {
            return await _context.sessions
                .Where(s => s.CUST_NAME == customerName)
                .ToListAsync();
        }

        public async Task<List<Scripts>> GetCustomerScriptsAsync(string accountCode)
        {
            var scripts = await _context.scripts
                                .Where(s => s.ACCNT_CODE == accountCode)
                                .ToListAsync();

            return scripts;
        }

        public async Task<List<Session>> GetSessionsByScriptCodeAsync(string code)
        {
            var Session = await _context.sessions
                                .Where(s => s.SESS_TMPL_ID == code).ToListAsync();

            return Session;

        }

        public async Task<string> ResetSessionAsync(string sessionId)
        {
            var session = await _context.sessions.FindAsync(sessionId);
            if (session == null)
            {
                return "Session not found";
            }

            var strategy = _context.Database.CreateExecutionStrategy();

            return await strategy.ExecuteAsync(async () =>
            {
                using (var transaction = await _context.Database.BeginTransactionAsync())
                {
                    try
                    {
                        // Reset fields
                        session.TOTAL = null;
                        session.DELIVERY_CHARGE = null;
                        session.DELIVERY_METHOD = null;
                        session.PAYMENT_METHOD = null;
                        session.DELIVERY_IN_CART = null;
                        session.CC_APPR = null;
                        session.CC_MSG = null;
                        session.CC_ID = null;
                        session.CC_TOKEN = null;
                        session.MAIN_WAID = null;
                        session.CUST_NAME = null;
                        session.ORDER_NUM = null;
                        session.CITY = null;
                        session.STREET_ADDR = null;
                        session.NOTES = null;
                        session.TMP_CHANGES_ANS = null;
                        session.RPTS = null;
                        session.LANG = null;

                        // Set the status to RESET
                        session.STATUS = "RESET";
                        await _context.SaveChangesAsync();

                        await transaction.CommitAsync();
                        return "Session reset successfully";
                    }
                    catch (Exception ex)
                    {
                        await transaction.RollbackAsync();
                        Console.WriteLine($"Error occurred: {ex.Message}");
                        return $"Error occurred: {ex.Message}";
                    }
                }
            });

        }




    }
}
