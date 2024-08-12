using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OrderManagementAPI.Models
{
    public class Session
    {
       
        public string? SESS_TMPL_ID { get; set; }
     
        public double? TOTAL {  get; set; }
        public double? DELIVERY_CHARGE {  get; set; }
        public string? DELIVERY_METHOD { get; set; }
        public string? PAYMENT_METHOD {  get; set; }
        public string? DELIVERY_IN_CART {  get; set; }

        public DateTime? CREATED { get; set; }
        public DateTime? ENDED {  get; set; }
        [Key]
        public required string SESSION {  get; set; }
        public string? CC_APPR {  get; set; }
        public string? CC_MSG { get; set; }

        public string? CC_ID { get; set; }
        public string? CC_TOKEN { get; set; }
        public string? MAIN_WAID { get; set; }
        public string? CUST_NAME { get; set; }
        public string? ORDER_NUM { get; set; }
        public string? CITY { get; set; }
        public string? STREET_ADDR { get; set; }
        public string? NOTES { get; set; }
        public string? STATUS { get; set; }
        public string? CUR_STEP { get; set; }
        public DateTime? CUR_STEP_UPD { get; set; }
        public string? TMP_CHANGES_ANS { get; set; }
        public string? RPTS { get; set; }
        public string? LANG { get; set; }

    }


}
