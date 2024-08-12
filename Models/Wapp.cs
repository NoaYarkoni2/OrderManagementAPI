using System.ComponentModel.DataAnnotations;

namespace OrderManagementAPI.Models
{
    public class Wapp
    {
        [Key]
        public required int ID { get; set; }
        public string? URL { get; set; }
        public string? PROVIDER { get; set; }
        public string? WAPP_NUMBER { get; set; }
        public string? WAPP_NS { get; set; }
        public DateTime TOKENEXP { get; set; }
        public string ACCNT_NAME { get; set; }
        public required string ACCNT_CODE { get; set; }
        public string ACCNT_ACTIVE { get; set; }
        public string ACCNT_TYPE { get; set; }
        public string KOSHER_TYPE { get; set; }
        public string ACCNT_PHONE { get; set; }
        public string ACCNT_ADDR { get; set; }
        public string ABOUT { get; set; }
        public string CC_TERM { get; set; }
        public string CC_PASS { get; set; }
        public string DEFAULT_SCRIPT { get; set; }

    }
}
