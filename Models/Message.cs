using System.ComponentModel.DataAnnotations;

namespace OrderManagementAPI.Models
{
    public class Message
    {
        [Key]
        public required string ID { get; set; }
        public string? WAID { get; set; }
        public string? WAMESID { get; set; }
        public string? SESSION { get; set; }
        public string? NAME { get; set; }
        public string? TMPL_MSG_ID { get; set; }
        public DateTime? D_DELIVERED { get; set; }
        public DateTime? D_READ { get; set; }
        public DateTime? D_SENT { get; set; }
        public DateTime? D_DELETED { get; set; }
        public string? SENT_FLG { get; set; }
        
        public string? STATUS { get; set; }
        public string? SEROBJ { get; set; }
        public string? TMPLID { get; set; }
        public string? VALIDATOR { get; set; }
        public string? EXPECTTYPE { get; set; }
        public string? NEXTMESSAGE { get; set; }
        public string? ANSWERTEXT { get; set; }
        public string? ANSWERHIST { get; set; }
        public string? MESTEXT { get; set; }
        public DateTime? CREATED { get; set; }
        public string? AGENT_ID { get; set; }
        public string? ALT_TEXT { get; set; }
        public string? MAIN_SESSION { get; set; }
        public string? RELATED_MSGS { get; set; }
    }
}
