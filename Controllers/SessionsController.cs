using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.Data;
using OrderManagementAPI.Interface;
using OrderManagementAPI.Models;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SessionsController : ControllerBase
    {
        private readonly ISessionRepository _sessionRepository;

        public SessionsController(ISessionRepository sessionRepository)
        {
            _sessionRepository = sessionRepository;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var session = await _sessionRepository.LoginAsync(request.ACCNT_CODE, request.SESS_TMPL_ID);
            if (session != null)
            {
                return Ok(session);
            }
            return Unauthorized("Invalid ACCNT_CODE or SESS_TMPL_ID");
        }
        [HttpGet("all")]
        public async Task<IActionResult> getSession()
        {
            var session = await _sessionRepository.GetAllSessionsAsync();
            return Ok(session);
        }
    }
}
