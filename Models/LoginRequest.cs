namespace OrderManagementAPI.Models
{
    public class LoginRequest
    {
        public required string ACCNT_CODE { get; set; }
        public required string SESS_TMPL_ID { get; set; }
    }
}
