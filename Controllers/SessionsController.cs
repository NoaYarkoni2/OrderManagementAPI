using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderManagementAPI.Data;
using OrderManagementAPI.Interface;
using OrderManagementAPI.Models;
using Org.BouncyCastle.Asn1.Ocsp;
using System.Reflection.Metadata;

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
        [HttpGet("get-all-session")]
        public async Task<IActionResult> getSession()
        {
            var session = await _sessionRepository.GetAllSessionsAsync();
            return Ok(session);
        }
        [HttpGet("get-session-name/{customerName}")]
        public async Task<IActionResult> getSessionByCustomer(string customerName)
        {
            try
            {
                var session = await _sessionRepository.GetSessionsByCustomerNameAsync(customerName);
                return Ok(session);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("get-script/{accountCode}")]
        public async Task<IActionResult> GetCustomerScript(string accountCode)
        {
            try
            {
                var script = await _sessionRepository.GetCustomerScriptsAsync(accountCode);
                return Ok(script);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }

        [HttpGet("get-session-code/{code}")]
        public async Task<IActionResult> GetCustomerSession(string code)
        {
            try
            {
                var session = await _sessionRepository.GetSessionsByScriptCodeAsync(code);
                return Ok(session);
            }
            catch (HttpRequestException ex)
            {
                return StatusCode(500, new { message = ex.Message });
            }
        }



        [HttpPost("reset-session")]
        public async Task<IActionResult> ResetSession(string sessionId)
        {
            try
            {
                await _sessionRepository.ResetMessageStatusAsync(sessionId);
                return Ok($"Session {sessionId} and its messages have been reset.");
            }
            catch (Exception ex)
            {
                return BadRequest($"Error occurred: {ex.Message}");
            }
   
        }

    }
}
