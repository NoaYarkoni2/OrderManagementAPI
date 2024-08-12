using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace OrderManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly DBUtilities _dbUtilities;

        public OrdersController()
        {
            _dbUtilities = new DBUtilities();
        }

        [HttpGet]
        public IActionResult GetOrders()
        {
            try
            {
                _dbUtilities.OpenConnection();
                // Execute your database operations here
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
            finally
            {
                _dbUtilities.CloseConnection();
            }

            return Ok();
        }
    }
}
