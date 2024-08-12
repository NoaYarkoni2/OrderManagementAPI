using System.ComponentModel.DataAnnotations;

namespace OrderManagementAPI.Models
{
    public class Scripts
    {
        [Key]
        public string ID { get; set; }
        public string NAME { get; set; }
        public string CODE { get; set; }
        public string PRE_WEB_HOOK { get; set; }
        public string GEN_WEB_HOOK { get; set; }
        public string TERM_WEB_HOOK { get; set; }
        public string START_WORD { get; set; }
        public string CANCEL_WORD { get; set; }
        public string REMOVE_WORD { get; set; }
        public string BACK_WORDS { get; set; }
        public string HELP_WORDS { get; set; }
        public string HELP_MESSAGE { get; set; }
        public string FST_STEP { get; set; }
        public string LAST_STEPS { get; set; }
        public required string ACCNT_CODE { get; set; }
        public string SCR_TYPE { get; set; }

        public string DEFAULT_LANG { get; set; }
        public string CHECK_REMOVED { get; set; }
        public string maintenance_mode { get; set; }

        public string maintenance_waids   { get; set; }

    }
}
